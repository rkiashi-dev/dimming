namespace HostSimulator
{
    partial class FrmMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.Protocol = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RemoteAddress = new System.Windows.Forms.TextBox();
            this.RemotePort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ListenPort = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Btn状態確認 = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.Btn設定状態 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.Channel設定 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dataONOFF = new System.Windows.Forms.CheckBox();
            this.BtnONOFF = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.ChannelONOFF = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.value発光 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.mode発光 = new System.Windows.Forms.ComboBox();
            this.Btn発光モード = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Channel発光 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Btn調光データ = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.Data調光 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Channel調光 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnStart = new System.Windows.Forms.Button();
            this.Log = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Protocol
            // 
            this.Protocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Protocol.FormattingEnabled = true;
            this.Protocol.Items.AddRange(new object[] {
            "UDP",
            "TCP"});
            this.Protocol.Location = new System.Drawing.Point(31, 27);
            this.Protocol.Name = "Protocol";
            this.Protocol.Size = new System.Drawing.Size(121, 26);
            this.Protocol.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(208, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "remote ip - port";
            // 
            // RemoteAddress
            // 
            this.RemoteAddress.Location = new System.Drawing.Point(367, 28);
            this.RemoteAddress.Name = "RemoteAddress";
            this.RemoteAddress.Size = new System.Drawing.Size(100, 25);
            this.RemoteAddress.TabIndex = 3;
            this.RemoteAddress.Text = "192.168.0.1";
            // 
            // RemotePort
            // 
            this.RemotePort.Location = new System.Drawing.Point(495, 29);
            this.RemotePort.Name = "RemotePort";
            this.RemotePort.Size = new System.Drawing.Size(83, 25);
            this.RemotePort.TabIndex = 4;
            this.RemotePort.Text = "8080";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "receive port";
            // 
            // ListenPort
            // 
            this.ListenPort.Location = new System.Drawing.Point(495, 60);
            this.ListenPort.Name = "ListenPort";
            this.ListenPort.Size = new System.Drawing.Size(83, 25);
            this.ListenPort.TabIndex = 6;
            this.ListenPort.Text = "8787";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Btn状態確認);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.Btn設定状態);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.Channel設定);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.dataONOFF);
            this.panel1.Controls.Add(this.BtnONOFF);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.ChannelONOFF);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.value発光);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.mode発光);
            this.panel1.Controls.Add(this.Btn発光モード);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.Channel発光);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.Btn調光データ);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.Data調光);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.Channel調光);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(30, 110);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(860, 411);
            this.panel1.TabIndex = 7;
            // 
            // Btn状態確認
            // 
            this.Btn状態確認.Location = new System.Drawing.Point(151, 344);
            this.Btn状態確認.Name = "Btn状態確認";
            this.Btn状態確認.Size = new System.Drawing.Size(75, 33);
            this.Btn状態確認.TabIndex = 30;
            this.Btn状態確認.Text = "送信";
            this.Btn状態確認.UseVisualStyleBackColor = true;
            this.Btn状態確認.Click += new System.EventHandler(this.Btn状態確認_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(27, 351);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(80, 18);
            this.label16.TabIndex = 27;
            this.label16.Text = "状態確認";
            // 
            // Btn設定状態
            // 
            this.Btn設定状態.Location = new System.Drawing.Point(145, 262);
            this.Btn設定状態.Name = "Btn設定状態";
            this.Btn設定状態.Size = new System.Drawing.Size(75, 31);
            this.Btn設定状態.TabIndex = 26;
            this.Btn設定状態.Text = "送信";
            this.Btn設定状態.UseVisualStyleBackColor = true;
            this.Btn設定状態.Click += new System.EventHandler(this.Btn設定状態_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(63, 301);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(66, 18);
            this.label14.TabIndex = 24;
            this.label14.Text = "channel";
            // 
            // Channel設定
            // 
            this.Channel設定.Location = new System.Drawing.Point(151, 298);
            this.Channel設定.Name = "Channel設定";
            this.Channel設定.Size = new System.Drawing.Size(65, 25);
            this.Channel設定.TabIndex = 23;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(27, 268);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(80, 18);
            this.label15.TabIndex = 22;
            this.label15.Text = "設定状態";
            // 
            // dataONOFF
            // 
            this.dataONOFF.AutoSize = true;
            this.dataONOFF.Location = new System.Drawing.Point(323, 214);
            this.dataONOFF.Name = "dataONOFF";
            this.dataONOFF.Size = new System.Drawing.Size(22, 21);
            this.dataONOFF.TabIndex = 21;
            this.dataONOFF.UseVisualStyleBackColor = true;
            // 
            // BtnONOFF
            // 
            this.BtnONOFF.Location = new System.Drawing.Point(145, 178);
            this.BtnONOFF.Name = "BtnONOFF";
            this.BtnONOFF.Size = new System.Drawing.Size(75, 34);
            this.BtnONOFF.TabIndex = 20;
            this.BtnONOFF.Text = "送信";
            this.BtnONOFF.UseVisualStyleBackColor = true;
            this.BtnONOFF.Click += new System.EventHandler(this.BtnONOFF_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(255, 217);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 18);
            this.label10.TabIndex = 19;
            this.label10.Text = "データ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(63, 220);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 18);
            this.label11.TabIndex = 17;
            this.label11.Text = "channel";
            // 
            // ChannelONOFF
            // 
            this.ChannelONOFF.Location = new System.Drawing.Point(151, 217);
            this.ChannelONOFF.Name = "ChannelONOFF";
            this.ChannelONOFF.Size = new System.Drawing.Size(65, 25);
            this.ChannelONOFF.TabIndex = 16;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(27, 186);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(111, 18);
            this.label12.TabIndex = 15;
            this.label12.Text = "ON/OFF設定";
            // 
            // value発光
            // 
            this.value発光.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.value発光.FormattingEnabled = true;
            this.value発光.Items.AddRange(new object[] {
            "none",
            "v_40us",
            "v_80us",
            "v_120us",
            "v_200us",
            "v_600us",
            "v_1m",
            "v_4m",
            "v_10m",
            "v_20m",
            "v_40m"});
            this.value発光.Location = new System.Drawing.Point(570, 137);
            this.value発光.Name = "value発光";
            this.value発光.Size = new System.Drawing.Size(131, 26);
            this.value発光.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(501, 140);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 18);
            this.label9.TabIndex = 13;
            this.label9.Text = "ストロボ";
            // 
            // mode発光
            // 
            this.mode発光.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mode発光.FormattingEnabled = true;
            this.mode発光.Items.AddRange(new object[] {
            "常時モード",
            "ONOFFモード",
            "ストロボモード"});
            this.mode発光.Location = new System.Drawing.Point(323, 136);
            this.mode発光.Name = "mode発光";
            this.mode発光.Size = new System.Drawing.Size(150, 26);
            this.mode発光.TabIndex = 12;
            // 
            // Btn発光モード
            // 
            this.Btn発光モード.Location = new System.Drawing.Point(145, 101);
            this.Btn発光モード.Name = "Btn発光モード";
            this.Btn発光モード.Size = new System.Drawing.Size(75, 31);
            this.Btn発光モード.TabIndex = 11;
            this.Btn発光モード.Text = "送信";
            this.Btn発光モード.UseVisualStyleBackColor = true;
            this.Btn発光モード.Click += new System.EventHandler(this.Btn発光モード_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(255, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 18);
            this.label6.TabIndex = 10;
            this.label6.Text = "モード";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(63, 140);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 18);
            this.label7.TabIndex = 8;
            this.label7.Text = "channel";
            // 
            // Channel発光
            // 
            this.Channel発光.Location = new System.Drawing.Point(151, 137);
            this.Channel発光.Name = "Channel発光";
            this.Channel発光.Size = new System.Drawing.Size(65, 25);
            this.Channel発光.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 18);
            this.label8.TabIndex = 6;
            this.label8.Text = "発光モード";
            // 
            // Btn調光データ
            // 
            this.Btn調光データ.Location = new System.Drawing.Point(145, 18);
            this.Btn調光データ.Name = "Btn調光データ";
            this.Btn調光データ.Size = new System.Drawing.Size(75, 32);
            this.Btn調光データ.TabIndex = 5;
            this.Btn調光データ.Text = "送信";
            this.Btn調光データ.UseVisualStyleBackColor = true;
            this.Btn調光データ.Click += new System.EventHandler(this.Btn調光データ_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(255, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "データ";
            // 
            // Data調光
            // 
            this.Data調光.Location = new System.Drawing.Point(323, 59);
            this.Data調光.Name = "Data調光";
            this.Data調光.Size = new System.Drawing.Size(65, 25);
            this.Data調光.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(63, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 18);
            this.label4.TabIndex = 2;
            this.label4.Text = "channel";
            // 
            // Channel調光
            // 
            this.Channel調光.Location = new System.Drawing.Point(155, 56);
            this.Channel調光.Name = "Channel調光";
            this.Channel調光.Size = new System.Drawing.Size(65, 25);
            this.Channel調光.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "調光データ";
            // 
            // BtnStart
            // 
            this.BtnStart.Location = new System.Drawing.Point(646, 28);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(85, 36);
            this.BtnStart.TabIndex = 8;
            this.BtnStart.Text = "開始";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // Log
            // 
            this.Log.Location = new System.Drawing.Point(41, 576);
            this.Log.Multiline = true;
            this.Log.Name = "Log";
            this.Log.Size = new System.Drawing.Size(848, 208);
            this.Log.TabIndex = 9;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(38, 535);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 18);
            this.label13.TabIndex = 10;
            this.label13.Text = "ログ";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 817);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.Log);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ListenPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RemotePort);
            this.Controls.Add(this.RemoteAddress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Protocol);
            this.Name = "FrmMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Protocol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox RemoteAddress;
        private System.Windows.Forms.TextBox RemotePort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ListenPort;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Btn調光データ;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Data調光;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Channel調光;
        private System.Windows.Forms.Button Btn発光モード;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Channel発光;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox mode発光;
        private System.Windows.Forms.ComboBox value発光;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button Btn状態確認;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button Btn設定状態;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox Channel設定;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox dataONOFF;
        private System.Windows.Forms.Button BtnONOFF;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox ChannelONOFF;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox Log;
        private System.Windows.Forms.Label label13;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

