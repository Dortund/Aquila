using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquila.Data
{
    class Planet
    {
        public Dictionary<Player, int> Players { get; protected set; }
        public int[] satelitePoints { get; protected set; }
        public Player[] sateliteOwner { get; protected set; }
        public int satelitesClaimed { get; protected set; }

        public Planet(int[] satelitePoints)
        {
            Players = new Dictionary<Player, int>();
            satelitesClaimed = 0;
            this.satelitePoints = satelitePoints;
            this.sateliteOwner = new Player[this.satelitePoints.Length];
        }

        public void Add(int stations, int cards, Player player)
        {
            if ((player.roundDown && stations > cards / 2) || (!player.roundDown && stations > cards + 1 / 2))
                throw new InvalidOperationException();

            if (!Players.ContainsKey(player))
                Players.Add(player, 0);

            Players[player] += stations;
        }

        public void Clear(Player player)
        {
            if (!Players.ContainsKey(player))
                Players.Add(player, 0);

            var res = Players[player];
            Players[player] = 0;
            player.Stations += res;
        }

        public void Establish(Player player, int cards)
        {
            if (satelitesClaimed == satelitePoints.Length)
                throw new InvalidOperationException();

            var tries = (player.roundDown ? cards : cards + 1) / 2;

            var stations = new List<Player>();
            foreach (var p in Players.Keys)
                for (int i = 0; i < Players[p]; i++ )
                    stations.Add(p);

            var r = new Random();
            var order = stations.OrderBy((a) => r.Next()).Take(tries);

            foreach (var p in order)
            {
                if (p != player)
                {
                    Players[p]--;
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
