namespace STBL_KEYENCE_CHANGE_FILE_NAME
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tbBarcode = new System.Windows.Forms.TextBox();
            this.lbBarcode = new System.Windows.Forms.Label();
            this.rTBResult = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.timerConnectSR1000 = new System.Windows.Forms.Timer(this.components);
            this.lbSRStatus = new System.Windows.Forms.Label();
            this.lbIP = new System.Windows.Forms.Label();
            this.bgWReadFile = new System.ComponentModel.BackgroundWorker();
            label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbBarcode
            // 
            this.tbBarcode.Enabled = false;
            this.tbBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBarcode.Location = new System.Drawing.Point(134, 12);
            this.tbBarcode.Name = "tbBarcode";
            this.tbBarcode.Size = new System.Drawing.Size(433, 31);
            this.tbBarcode.TabIndex = 0;
            // 
            // lbBarcode
            // 
            this.lbBarcode.AutoSize = true;
            this.lbBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBarcode.Location = new System.Drawing.Point(12, 15);
            this.lbBarcode.Name = "lbBarcode";
            this.lbBarcode.Size = new System.Drawing.Size(116, 25);
            this.lbBarcode.TabIndex = 1;
            this.lbBarcode.Text = "Bracode :: ";
            // 
            // rTBResult
            // 
            this.rTBResult.Location = new System.Drawing.Point(287, 49);
            this.rTBResult.Name = "rTBResult";
            this.rTBResult.Size = new System.Drawing.Size(280, 147);
            this.rTBResult.TabIndex = 2;
            this.rTBResult.Text = "";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 139);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(259, 57);
            this.button1.TabIndex = 3;
            this.button1.Text = "Scan";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timerConnectSR1000
            // 
            this.timerConnectSR1000.Tick += new System.EventHandler(this.timerConnectSR1000_Tick);
            // 
            // lbSRStatus
            // 
            this.lbSRStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbSRStatus.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lbSRStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSRStatus.Location = new System.Drawing.Point(12, 69);
            this.lbSRStatus.Name = "lbSRStatus";
            this.lbSRStatus.Size = new System.Drawing.Size(259, 23);
            this.lbSRStatus.TabIndex = 4;
            this.lbSRStatus.Text = "Status";
            this.lbSRStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbIP
            // 
            this.lbIP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbIP.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lbIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIP.Location = new System.Drawing.Point(12, 46);
            this.lbIP.Name = "lbIP";
            this.lbIP.Size = new System.Drawing.Size(259, 23);
            this.lbIP.TabIndex = 5;
            this.lbIP.Text = "IP Camera";
            this.lbIP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bgWReadFile
            // 
            this.bgWReadFile.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWReadFile_DoWork);
            // 
            // label1
            // 
            label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            label1.Location = new System.Drawing.Point(351, 199);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(216, 13);
            label1.TabIndex = 15;
            label1.Text = "Copyright© 2022 Thai SIIX CO.,LTD.";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 217);
            this.Controls.Add(label1);
            this.Controls.Add(this.lbIP);
            this.Controls.Add(this.lbSRStatus);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rTBResult);
            this.Controls.Add(this.lbBarcode);
            this.Controls.Add(this.tbBarcode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "STBL Update File to serial";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbBarcode;
        private System.Windows.Forms.Label lbBarcode;
        private System.Windows.Forms.RichTextBox rTBResult;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timerConnectSR1000;
        private System.Windows.Forms.Label lbSRStatus;
        private System.Windows.Forms.Label lbIP;
        private System.ComponentModel.BackgroundWorker bgWReadFile;
    }
}

