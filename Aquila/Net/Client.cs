using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Aquila.Net
{
    class Client
    {
        public Data.Player Player { get; set; }
        public TcpClient Client { get; set; }

        public Client(TcpClient client)
        {
            Client = client;
        }
    }
}
