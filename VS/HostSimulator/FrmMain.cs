using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using DimmingCommunicationLibrary;

namespace HostSimulator
{
    public partial class FrmMain : Form
    {
        private UdpClient receiver;
        private UdpClient sender;


        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.Protocol.SelectedIndex = 0;
            this.mode発光.SelectedIndex = 0;
            this.value発光.SelectedIndex = 0;
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            this.Log.AppendText("開始> " + this.RemoteAddress.Text + ":" + this.RemotePort.Text + " @ Local Port " + this.ListenPort.Text + System.Environment.NewLine);
            this.Log.AppendText("開始> " + this.Protocol.SelectedItem + System.Environment.NewLine);

            switch( this.Protocol.SelectedItem )
            {
                case "UDP":
                    this.receiver = new UdpClient(int.Parse(this.ListenPort.Text));
                    IPEndPoint remote = new IPEndPoint(IPAddress.Parse(this.RemoteAddress.Text), int.Parse(this.RemotePort.Text));
                    this.sender = new UdpClient(remote);
                    break;
                default:
                    this.Log.AppendText("開始> " + this.Protocol.SelectedItem + " はサポートされていません" + System.Environment.NewLine);
                    return;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void Btn調光データ_Click(object sender, EventArgs e)
        {
            byte[] data = SendMessage.調光データ設定電文(int.Parse(this.Channel調光.Text), byte.Parse(this.Data調光.Text)).GetMessage();
            this.sender.Send(data, data.Length);
            this.ReceiveData();
        }

        private void Btn発光モード_Click(object sender, EventArgs e)
        {
            発光モード mode = (発光モード)Enum.Parse(typeof(発光モード), mode発光.Text);
            ストロボ val = (ストロボ)Enum.Parse(typeof(ストロボ), value発光.Text);
            byte[] data = SendMessage.発光モード設定電文(int.Parse(this.Channel発光.Text), mode, val).GetMessage();
            this.sender.Send(data, data.Length);
            this.ReceiveData();
        }

        private void BtnONOFF_Click(object sender, EventArgs e)
        {
            byte[] data = SendMessage.ONOFF設定電文(int.Parse(this.ChannelONOFF.Text), this.dataONOFF.Checked).GetMessage();
            this.sender.Send(data, data.Length);
            this.ReceiveData();
        }

        private void Btn設定状態_Click(object sender, EventArgs e)
        {
            byte[] data = SendMessage.設定状態確認電文(int.Parse(this.Channel設定.Text)).GetMessage();
            this.sender.Send(data, data.Length);
            this.ReceiveData();
        }

        private void Btn状態確認_Click(object sender, EventArgs e)
        {
            byte[] data = SendMessage.状態確認電文().GetMessage();
            this.sender.Send(data, data.Length);
            this.ReceiveData();
        }

        private void ReceiveData()
        {
            IPEndPoint remote = null;
            byte[] ret = this.receiver.Receive(ref remote);
            this.Log.AppendText("受信> " + ASCIIEncoding.ASCII.GetString( ret ) + System.Environment.NewLine);
        }
    }
}
