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
        public TcpClient Socket { get; set; }
        public Data.Game Game { get; set; }

        public Client(TcpClient client)
        {
            Socket = client;
        }

        public void Process()
        {

        }
    }
}
