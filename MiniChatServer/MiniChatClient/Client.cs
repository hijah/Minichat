using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MiniChatClient
{
    class Client
    {
        public void start()
        {
            using (TcpClient socket = new TcpClient("localhost", 7070))
            using (NetworkStream ns = socket.GetStream())
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))
                while (true)
                {
                    string myline = Console.ReadLine();
                    sw.WriteLine(myline);
                    sw.Flush();
                    string line = sr.ReadLine();
                    Console.WriteLine(line);
                    if (myline == "STOP" || line == "STOP")
                    {
                        break;
                    }
                }
        }
    }
}
