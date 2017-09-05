using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace MiniChatServer
{
    public class Server
    {
        public void DoClient(TcpClient socket)
        {

            using (NetworkStream ns = socket.GetStream())
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
                        socket.Close();
                    }
                }
        }

        public void start()
        {
            TcpListener server = new TcpListener(IPAddress.Loopback, 7070);
            server.Start();
            using (TcpClient socket = server.AcceptTcpClient())
                DoClient(socket);

        }
    }
}