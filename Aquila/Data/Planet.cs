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
        protected int[] satelitePoints;
        protected Player[] sateliteOwner;
        protected int satelitesClaimed = 0;

        public Planet(int[] satelitePoints)
        {
            this.satelitePoints = satelitePoints;
            this.sateliteOwner = new Player[this.satelitePoints.Length];
        }

        public void Add(int stations, int cards, Player player)
        {
            if ((player.roundDown && stations > cards / 2) || (!player.roundDown && stations > cards + 1 / 2))
                throw new InvalidOperationException();

            if (!players.ContainsKey(player))
                players.Add(player, 0);

            players[player] += stations;
        }

        public void Clear(Player player)
        {
            if (!players.ContainsKey(player))
                players.Add(player, 0);

            var res = players[player];
            players[player] = 0;
            player.Stations += res;
        }

        public void Establish(Player player, int cards)
        {
            if (satelitesClaimed == satelitePoints.Length)
                throw new InvalidOperationException();

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
                    sateliteOwner[satelitesClaimed] = p;
                    satelitesClaimed++;
                    break;
                }
            }
        }

        public int GetPoints(Player player)
        {
            var res = 0;
            for (int i = 0; i < sateliteOwner.Length; i++)
                if (sateliteOwner[i] == player)
                    res += satelitePoints[i];
            return res;
        }
    }
}
