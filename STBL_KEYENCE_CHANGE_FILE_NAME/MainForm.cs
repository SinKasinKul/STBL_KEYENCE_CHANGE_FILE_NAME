using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Threading;

namespace STBL_KEYENCE_CHANGE_FILE_NAME
{
    public partial class MainForm : Form
    {
        string SocketIP, SocketPort, SocketConnect;
        string MainBarcode;

        public delegate void callrichtext(String ss);
        public callrichtext myDelegateStatus;
        public delegate void callrichtext1(String ss);
        public callrichtext1 myDelegateReceive;

        private static Socket _ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private const int BUFFER_SIZE = 1024;
        private static readonly byte[] buffer = new byte[BUFFER_SIZE];
        public MainForm()
        {
            InitializeComponent();
            SocketIP = "10.0.112.165";
            SocketPort = "9004";
            TextBox.CheckForIllegalCrossThreadCalls = false;
            ConnectToSR1000();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SR1000Scan();
        }

        private void SR1000Scan()
        {
            SendText("LON\r");
            Thread.Sleep(1000);
            SendText("LOFF\r");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SR1000Scan();
        }
        private void SendText(string text)
        {
            try
            {
                byte[] message = Encoding.ASCII.GetBytes(text);
                _ClientSocket.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), _ClientSocket);
            }
            catch (Exception ex)
            {
                ResultStatus("Error Msg :: " + ex);
            }
        }
        private void ConnectToSR1000()
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(SocketIP), int.Parse(SocketPort));
            _ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _ClientSocket.Connect(iep);
            rTBResult.Text = _ClientSocket.Connected.ToString();
        }
        private void ReceiveData(IAsyncResult iar)
        {
            try
            {
                int received;
                try
                {
                    received = _ClientSocket.EndReceive(iar);
                }
                catch (SocketException)
                {
                    return;
                }

                if (received == 0) return;
                var data = new byte[received];
                Array.Copy(buffer, data, received);
                string receivedData = Encoding.ASCII.GetString(data);

                ResultStatus(receivedData);
            }
            catch (Exception ex)
            {
                string vExReceive = "Failed Receive";
                rTBResult.Invoke(this.myDelegateReceive, new Object[] { vExReceive });
            }
        }
        private void SendData(IAsyncResult iar)
        {
            int sent;
            try
            {
                sent = _ClientSocket.EndReceive(iar);
            }
            catch (SocketException)
            {
                _ClientSocket.Close();
                return;
            }

            if (sent == 0) return;
            try
            {
                _ClientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveData), _ClientSocket);
            }
            catch (Exception ex)
            {
                ResultStatus(ex.Message);
            }
        }
        public void ResultStatus(string RText)
        {
            string dateLog = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            rTBResult.AppendText(dateLog + "----> " + RText);
            rTBResult.AppendText(Environment.NewLine);
        }
    }
}
