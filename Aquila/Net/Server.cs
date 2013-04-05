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
        public TcpListener Server { get; protected set; }
        public bool IsRunning { get; set; }

        public Server()
        {
            Task.Factory.StartNew(() =>
            {
                if(IsRunning)
                    return;
                IsRunning = true;

                Server = new TcpListener(IPAddress.Any, 35353);
                Server.Start();

                while (IsRunning)
                {
                    var client = Server.AcceptTcpClient();

                }
                Server.Stop();
            }, TaskCreationOptions.LongRunning);
        }
    }
}
