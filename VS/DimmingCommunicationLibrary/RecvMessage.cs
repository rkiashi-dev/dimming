using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DimmingCommunicationLibrary
{
    public enum NG理由
    {
        コマンド不良エラー = 1,
        チェックサムエラー = 2,
        設定値版範囲外エラー = 3,

    }

    static class NG理由Extensions
    {
        public static char[] ToCharArray(this NG理由 reason)
        {
            return String.Format("{0:D2}", reason ).ToUpper().ToCharArray();
        }
        public static NG理由 parse( char p1, char p2 )
        {
            if( p1 != '0' ) { throw new ArgumentException("ng reason is bad."); }

            switch( p2 )
            {
                case '1':
                    return NG理由.コマンド不良エラー;
                case '2':
                    return NG理由.チェックサムエラー;
                case '3':
                    return NG理由.設定値版範囲外エラー;
                default:
                    throw new ArgumentException("ng reason is bad.");
            }
        }

    }

    public class RecvMessage : Message
    {
        protected RecvMessage()
        {
            this.Direction = Direction.DimmingToHost;
        }

        public static RecvMessage 調光データ設定電文( int channel, bool isOK, NG理由 reason )
        {
            RecvMessage message = new RecvMessage();
            message.SetChannel(channel);
            message.body = isOK 
                ? new char[] { 'O' } 
                : new char[] { 'N' }.Concat(reason.ToCharArray()).ToArray();
            message.CalcChecksum();
            return message;
        }
        public static RecvMessage 発光モード設定電文(int channel, bool isOK, NG理由 reason)
        {
            return 調光データ設定電文(channel,isOK,reason);
        }
        public static RecvMessage ONOFF設定電文(int channel, bool isOK, NG理由 reason)
        {
            return 調光データ設定電文(channel, isOK, reason);
        }
        public static RecvMessage 設定状態確認OK電文(int channel, byte 調光データ, ストロボ val, bool isActive )
        {
            RecvMessage message = new RecvMessage();
            message.SetChannel(channel);
            StringBuilder sb = new StringBuilder();
            sb.Append('O')
                .Append('F')
                    .Append(String.Format("{0:D3}", 調光データ))
                .Append(".S")
                    .Append(String.Format("{0:D2}", val))
                .Append(".L")
                    .Append(isActive ? '1' : '0')
            ;
            message.body = sb.ToString().ToCharArray();
            message.CalcChecksum();
            return message;
        }
        public static RecvMessage 設定状態確認NG電文(int channel, NG理由 reason)
        {
            RecvMessage message = new RecvMessage();
            message.SetChannel(channel);
            message.body = new char[] { 'N' }.Concat(reason.ToCharArray()).ToArray();
            message.CalcChecksum();
            return message;
        }
        public static RecvMessage 状態確認OK電文(int channel, bool isState)
        {
            RecvMessage message = new RecvMessage();
            message.SetChannel(channel);
            char[] state;
            if( isState )
            {
                state = new char[] { '0', '0' };
            }
            else
            {
                state = new char[] { '1', '1' };
            }
            message.body = new char[] { 'O' }.Concat(state).ToArray();
            message.CalcChecksum();
            return message;
        }
        public static RecvMessage 状態確認NG電文(int channel, NG理由 reason)
        {
            RecvMessage message = new RecvMessage();
            message.SetChannel(channel);
            message.body = new char[] { 'N' }.Concat(reason.ToCharArray()).ToArray();
            message.CalcChecksum();
            return message;
        }

        public static RecvMessage MakeRecvMessage( char 送信命令, char[] data )
        {
            if( data[0] != '@' ) { throw new ArgumentException("header is bad.");  }
            StringBuilder sb = new StringBuilder();
            int channel = Convert.ToInt32( sb.Append(data[1]).Append(data[2]).ToString(), 16 );

            bool isOk = false;
            NG理由 reason = NG理由.コマンド不良エラー;
            switch (送信命令)
            {
                case 'F':
                    isOk = data[3] == 'O';
                    if ( !isOk )
                    {
                        reason = NG理由Extensions.parse( data[4], data[5] );
                    }
                    return 調光データ設定電文(channel, isOk, reason);
                case 'S':
                    isOk = data[3] == 'O';
                    if (!isOk)
                    {
                        reason = NG理由Extensions.parse(data[4], data[5]);
                    }
                    return 発光モード設定電文(channel, isOk, reason);
                case 'L':
                    isOk = data[3] == 'O';
                    if (!isOk)
                    {
                        reason = NG理由Extensions.parse(data[4], data[5]);
                    }
                    return ONOFF設定電文(channel, isOk, reason);
                case 'M':
                    isOk = data[3] == 'O';
                    if (!isOk)
                    {
                        reason = NG理由Extensions.parse(data[4], data[5]);
                        return 設定状態確認NG電文(channel, reason);
                    }

                    byte 調光データ;
                    ストロボ val;

                    if( data[4] != 'F' ) { throw new ArgumentException("設定状態確認OK");  }
                    sb.Clear();
                    調光データ = Convert.ToByte(sb.Append(data[5]).Append(data[6]).Append(data[7]).ToString());
                    if (data[8] != '.') { throw new ArgumentException("設定状態確認OK"); }
                    if (data[9] != 'S') { throw new ArgumentException("設定状態確認OK"); }
                    int valInt = Convert.ToInt32(sb.Append(data[10]).Append(data[11]).ToString());
                    val = (ストロボ)Enum.ToObject(typeof(ストロボ), valInt);
                    if (data[12] != '.') { throw new ArgumentException("設定状態確認OK"); }
                    if (data[13] != 'L') { throw new ArgumentException("設定状態確認OK"); }

                    return 設定状態確認OK電文(channel, 調光データ, val, data[14] == '1');
                case 'C':
                    isOk = data[3] == 'O';
                    if (!isOk)
                    {
                        reason = NG理由Extensions.parse(data[4], data[5]);
                        return 状態確認NG電文(channel, reason);
                    }
                    bool state = false;
                    if( data[4] == '0' && data[5] == '0' ) { state = true; }
                    return 状態確認OK電文(channel, state);
                default:
                    throw new ArgumentException("RecvMessage parse is bad.");
            }
        }
    }
}
