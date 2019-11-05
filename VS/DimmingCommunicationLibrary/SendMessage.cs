using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DimmingCommunicationLibrary
{

    public class SendMessage : Message
    {
        SendMessage()
        {
            this.Direction = Direction.HostToDimming;
        }

        public static SendMessage 調光データ設定電文( int channel, byte data )
        {
            SendMessage message = new SendMessage();
            message.SetChannel(channel);

            message.body = new char[] { 'F' }.Concat(
                String.Format("{0:D3}", data).ToUpper().ToCharArray()
            ).ToArray();
            message.CalcChecksum();

            return message;
        }
        public static SendMessage 発光モード設定電文(int channel, 発光モード mode, ストロボ val)
        {
            SendMessage message = new SendMessage();
            message.SetChannel(channel);

            switch( mode )
            {
                case 発光モード.常時モード:
                case 発光モード.ONOFFモード:
                    message.body = new char[] { 'S' }.Concat(
                        String.Format("{0:D2}", 0).ToUpper().ToCharArray()
                    ).ToArray();
                    break;
                case 発光モード.ストロボモード:
                    message.body = new char[] { 'S' }.Concat(
                        String.Format("{0:D2}", val).ToUpper().ToCharArray()
                    ).ToArray();
                    break;
            }

            message.CalcChecksum();

            return message;
        }
        public static SendMessage ONOFF設定電文(int channel, bool isActive)
        {
            SendMessage message = new SendMessage();
            message.SetChannel(channel);

            message.body = new char[] { 'F', (isActive ? '1' : '0') };
            message.CalcChecksum();

            return message;
        }
        public static SendMessage 設定状態確認電文(int channel)
        {
            SendMessage message = new SendMessage();
            message.SetChannel(channel);

            message.body = new char[] { 'M' };
            message.CalcChecksum();

            return message;
        }
        public static SendMessage 状態確認電文()
        {
            SendMessage message = new SendMessage();
            message.SetChannel(0);

            message.body = new char[] { 'C' };
            message.CalcChecksum();

            return message;
        }

        public static SendMessage MakeSendMessage(char[] data)
        {
            if (data[0] != '@') { throw new ArgumentException("header is bad."); }
            StringBuilder sb = new StringBuilder();
            int channel = Convert.ToInt32(sb.Append(data[1]).Append(data[2]).ToString(), 16);

            switch (data[3])
            {
                case 'F':
                    byte 調光データ;
                    調光データ = Convert.ToByte(sb.Append(data[4]).Append(data[5]).Append(data[6]).ToString());
                    return 調光データ設定電文(channel, 調光データ);
                case 'S':
                    ストロボ val;
                    int valInt = Convert.ToInt32(sb.Append(data[4]).Append(data[5]).ToString());
                    val = (ストロボ)Enum.ToObject(typeof(ストロボ), valInt);
                    return 発光モード設定電文(channel, val == ストロボ.none ? 発光モード.ONOFFモード : 発光モード.ストロボモード, val);
                case 'L':
                    return ONOFF設定電文(channel, data[4] == '1');
                case 'M':
                    return 設定状態確認電文(channel);
                case 'C':
                    return 状態確認電文();
                default:
                    throw new ArgumentException("SendMessage parse is bad.");
            }
        }
    }
}
