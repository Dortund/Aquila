using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquila.Data
{
    class Planet
    {
        protected Dictionary<Player, int> players = new Dictionary<Player, int>();


        public void add(int stations, int cards, Player player)
        {
            if ((player.roundDown && stations > cards / 2) || (!player.roundDown && stations > cards + 1 / 2))
                throw new InvalidOperationException();

            if (!players.ContainsKey(player))
                players.Add(player, 0);

            players[player] += stations;
        }

        public void clear(Player player)
        {
            if (!players.ContainsKey(player))
                players.Add(player, 0);

            var res = players[player];
            players[player] = 0;
            player.Stations += res;
        }

        public void establish(Player player, int cards)
        {
            var tries = (player.roundDown ? cards : cards + 1) / 2;

            var stations = new List<Player>();
            foreach (var p in players.Keys)
                for (int i = 0; i < players[p]; i++ )
                    stations.Add(p);

            var r = new Random();
            var order = stations.OrderBy((a) => r.Next()).Take(tries);

            foreach (var p in order)
            {
                if (p != player)
                {
                    players[p]--;
                    player.Stations++;
                }
                else
                {

                    break;
                }
            }
        }
    }
}
