using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Aquila.Net
{
    class Server
    {
        public TcpListener Socket { get; protected set; }
        public bool IsRunning { get; set; }

        public Server()
        {
            Task.Factory.StartNew(() =>
            {
                if(IsRunning)
                    return;
                IsRunning = true;

                Socket = new TcpListener(IPAddress.Any, 35353);
                Socket.Start();

                while (IsRunning)
                {
                    var client = new Client(Socket.AcceptTcpClient());
                    Task.Factory.StartNew(() =>
                        {
                            client.Process();
                        }, TaskCreationOptions.LongRunning);
                }
                Socket.Stop();
            }, TaskCreationOptions.LongRunning);
        }
    }
}
