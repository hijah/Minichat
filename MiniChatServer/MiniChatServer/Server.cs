using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace MiniChatServer
{
    public class Server
    {
        public void start()
        {
            TcpListener server = new TcpListener(IPAddress.Loopback, 7070);
            server.Start();

            using (TcpClient client = server.AcceptTcpClient())
            using (NetworkStream ns = client.GetStream())
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))
                while (true)
                {
                    string line = sr.ReadLine();
                    Console.WriteLine(line);
                    string myline = Console.ReadLine();
                    sw.WriteLine(myline);

                    sw.Flush();
                    if (myline == "STOP" || line == "STOP")
                    {
                        break;
                    }
                }
            server.Stop();


        }
    }
}