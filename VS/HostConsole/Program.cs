using DimmingCommunicationLibrary;
using System;

namespace HostConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            SendMessage message = SendMessage.調光データ設定電文(0, 0);
            Console.WriteLine("START");
            Console.WriteLine(message.GetMessage());
        }
    }
}
