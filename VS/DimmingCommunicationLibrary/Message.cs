using System;
using System.Linq;

namespace DimmingCommunicationLibrary
{
    public enum Direction
    {
        HostToDimming, // 送信データ
        DimmingToHost  // 受信データ
    }
    public enum 発光モード
    {
        常時モード,
        ONOFFモード,
        ストロボモード
    }
    public enum ストロボ
    {
        none = 0,
        v_40us = 1,
        v_80us = 2,
        v_120us = 3,
        v_200us = 4,
        v_600us = 5,
        v_1m = 6,
        v_4m = 7,
        v_10m = 8,
        v_20m = 9,
        v_40m = 10
    }

    public class Message
    {
        protected readonly char[] header = new char[] { '@' };
        protected char[] channel;
        protected char[] body;
        public char[] Checksum { get; protected set; }
        protected Direction Direction { get; set ; }

        protected readonly char[] delimiter = new char[]{ Convert.ToChar(0x13), Convert.ToChar(0x10) } ;
        public const int 全チャネル指定 = 255;

        public void SetChannel( int id )
        {
            if( id < 0 ) { throw new ArgumentOutOfRangeException("チャンネルは0以上");  }
            if (id >= 100) { throw new ArgumentOutOfRangeException("チャンネルは2桁まで指定可能"); }

            this.channel = String.Format("{0:00}",id).ToUpper().ToCharArray();
        }
        public void SetBody( char[] body )
        {
            this.body = body;
        }

        public byte[] GetMessage()
        {
            this.CalcChecksum();
            return this.header.Concat(this.channel).Concat(this.body).Concat(this.Checksum).Select( c=> Convert.ToByte(c)).ToArray();
        }

        protected void CalcChecksum()
        {
            int sum = 0x0;

            sum += Convert.ToInt32(header[0]);
            sum += this.channel.Select(c => Convert.ToInt32(c)).Sum();
            sum += this.body.Select(c => Convert.ToInt32(c)).Sum();

            String tmp = String.Format("{0:X2}", sum);
            this.Checksum = tmp.Substring(tmp.Length - 2, 2).ToUpper().ToCharArray();
        }

    }
}
