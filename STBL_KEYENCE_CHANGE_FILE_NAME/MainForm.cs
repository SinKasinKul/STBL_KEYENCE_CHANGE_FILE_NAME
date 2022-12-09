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
using System.Configuration;
using System.IO;
using System.Xml.Linq;

namespace STBL_KEYENCE_CHANGE_FILE_NAME
{
    public partial class MainForm : Form
    {
        string SocketIP, SocketPort;
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
            var appSettings = ConfigurationManager.AppSettings;
            string vIP = appSettings.Get("IP");
            string vPort = appSettings.Get("Port");
            SocketIP = vIP;
            SocketPort = vPort;
            TextBox.CheckForIllegalCrossThreadCalls = false;
            ConnectToSR1000();
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Int32 TimeInt = 1000;
            timerConnectSR1000.Interval = TimeInt;
            timerConnectSR1000.Tick += new EventHandler(timerConnectSR1000_Tick);
            timerConnectSR1000.Enabled = true;

            lbIP.Text = SocketIP;
        }

        private void SR1000Scan()
        {
            if (_ClientSocket.Connected)
            {
                SendText("LON\r");
                Thread.Sleep(1000);
                SendText("LOFF\r");
                tbBarcode.Text = MainBarcode;
            }
        }
        private void UpdateFileName()
        {
            try
            {
                rTBResult.Text = "";
                var appSettings = ConfigurationManager.AppSettings;
                string pahtFile = appSettings.Get("Path");

                string pathBackUp = pahtFile + "Backup\\";
                string Date = DateTime.Now.ToString("yyyyMMdd");
                string DateII = DateTime.Now.ToString("yyyyMMddHHmmss");
                string BackUpdir = pathBackUp + Date + "\\";

                if (!Directory.Exists(BackUpdir))
                {
                    Directory.CreateDirectory(BackUpdir);
                }

                string[] txtList = Directory.GetFiles(pahtFile, "*.jpeg");
                if (txtList.Length > 0)
                {
                    SR1000Scan();

                    string NewFileName = MainBarcode.Substring(0, MainBarcode.Length - 2) + "_" + DateII + ".jpeg";
                    foreach (string sf in txtList)
                    {
                        string fName = sf.Substring(pahtFile.Length);
                        try
                        {
                            if (MainBarcode.Length > 0)
                            {
                                File.Move(pahtFile + fName, BackUpdir + NewFileName);
                                ResultStatus("Move " + fName + " success.");
                                tbBarcode.Text = "";
                                MainBarcode = "";
                            }
                        }
                        catch
                        {
                            ResultStatus("Move " + fName + " fail.");
                            tbBarcode.Text = "";
                            MainBarcode = "";
                        }
                        
                    }
                }
            }
            catch (Exception Ex)
            {
                ResultStatus("Path file have been error.");
            }
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
            try
            {
                IPEndPoint iep = new IPEndPoint(IPAddress.Parse(SocketIP), int.Parse(SocketPort));
                _ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _ClientSocket.Connect(iep);
                ResultStatus("Connected");
                lbSRStatus.Text = "Connected";
                lbSRStatus.BackColor = Color.MediumSeaGreen;
                lbSRStatus.ForeColor = Color.White;
            }
            catch (Exception Ex)
            {
                ResultStatus("Connection Error");
                lbSRStatus.Text = "Connection Error";
                lbSRStatus.BackColor = Color.Red;
                lbSRStatus.ForeColor = Color.White;
            }
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
                MainBarcode = receivedData;
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
        private void timerConnectSR1000_Tick(object sender, EventArgs e)
        {
            if (bgWReadFile.IsBusy != true)
            {
                bgWReadFile.RunWorkerAsync();
            }

            int Date = int.Parse(DateTime.Now.ToString("ss"));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateFileName();
        }

        private void bgWReadFile_DoWork(object sender, DoWorkEventArgs e)
        {
            UpdateFileName();
        }

        public void ResultStatus(string RText)
        {
            string dateLog = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            rTBResult.AppendText(dateLog + "----> " + RText);
            rTBResult.AppendText(Environment.NewLine);
        }
    }
}
