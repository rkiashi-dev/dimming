using DimmingCommunicationLibrary;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace DimmingConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener server = new TcpListener(IPAddress.Loopback, 7778);
            server.Start();
            Console.WriteLine("Wait Client");
            TcpClient client = server.AcceptTcpClient();
            Console.WriteLine("Accept Client");
            using (StreamReader sr = new StreamReader(client.GetStream()))
            {
                String tmp = sr.ReadLine();

                SendMessage message = SendMessage.MakeSendMessage(tmp.ToCharArray());
                Console.WriteLine("");
            }
        }
    }
}
