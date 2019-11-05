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
        private UdpClient udpReceiver;
        private UdpClient udpSender;
        private TcpListener tcpAcceptor;
        private TcpClient tcpSender;
        private TcpClient tcpReceiver;

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

            IPEndPoint remote = new IPEndPoint(IPAddress.Parse(this.RemoteAddress.Text), int.Parse(this.RemotePort.Text));
            switch ( this.Protocol.SelectedItem )
            {
                case "UDP":
                    this.udpReceiver = new UdpClient(int.Parse(this.ListenPort.Text));
                    this.udpSender = new UdpClient(remote);
                    break;
                case "TCP":
                    this.tcpAcceptor = new TcpListener(int.Parse(this.ListenPort.Text));
                    this.tcpSender = new TcpClient();
                    this.Log.AppendText("開始> クライアントへの接続" + System.Environment.NewLine);
                    this.tcpSender.Connect(remote);
                    this.Log.AppendText("開始> クライアントからの接続待機" + System.Environment.NewLine);
                    this.tcpAcceptor.Start();
                    this.tcpReceiver = this.tcpAcceptor.AcceptTcpClient();
                    break;
                default:
                    this.Log.AppendText("開始> " + this.Protocol.SelectedItem + " はサポートされていません" + System.Environment.NewLine);
                    return;
            }
        }

        private void SendReceive(byte[] data)
        {
            this.Log.AppendText("送信> " + ASCIIEncoding.ASCII.GetString(data) + System.Environment.NewLine);
            byte[] ret = null;
            switch ( this.Protocol.SelectedItem )
            {
                case "UDP":
                    this.udpSender.Send(data, data.Length);

                    IPEndPoint remote = null;
                    this.udpReceiver.Receive(ref remote);
                    this.Log.AppendText("受信> " + ASCIIEncoding.ASCII.GetString(ret) + System.Environment.NewLine);
                    break;
                case "TCP":
                    NetworkStream input = this.tcpSender.GetStream();
                    input.Write(data, 0, data.Length);

                    NetworkStream output = this.tcpReceiver.GetStream();
                    byte[] tmp = new byte[512];
                    int len = output.Read(tmp, 0, 512);
                    ret = new byte[len];
                    Array.Copy(tmp, 0, ret, 0, len);
                    this.Log.AppendText("受信> " + ASCIIEncoding.ASCII.GetString(ret) + System.Environment.NewLine);
                    break;
                default:
                    this.Log.AppendText("送受信> " + this.Protocol.SelectedItem + " はサポートされていません" + System.Environment.NewLine);
                    return;
            }
        }

        private void Btn調光データ_Click(object sender, EventArgs e)
        {
            byte[] data = SendMessage.調光データ設定電文(int.Parse(this.Channel調光.Text), byte.Parse(this.Data調光.Text)).GetMessage();
            this.SendReceive(data);
        }

        private void Btn発光モード_Click(object sender, EventArgs e)
        {
            発光モード mode = (発光モード)Enum.Parse(typeof(発光モード), mode発光.Text);
            ストロボ val = (ストロボ)Enum.Parse(typeof(ストロボ), value発光.Text);
            byte[] data = SendMessage.発光モード設定電文(int.Parse(this.Channel発光.Text), mode, val).GetMessage();
            this.SendReceive(data);
        }

        private void BtnONOFF_Click(object sender, EventArgs e)
        {
            byte[] data = SendMessage.ONOFF設定電文(int.Parse(this.ChannelONOFF.Text), this.dataONOFF.Checked).GetMessage();
            this.SendReceive(data);
        }

        private void Btn設定状態_Click(object sender, EventArgs e)
        {
            byte[] data = SendMessage.設定状態確認電文(int.Parse(this.Channel設定.Text)).GetMessage();
            this.SendReceive(data);
        }

        private void Btn状態確認_Click(object sender, EventArgs e)
        {
            byte[] data = SendMessage.状態確認電文().GetMessage();
            this.SendReceive(data);
        }

    }
}
