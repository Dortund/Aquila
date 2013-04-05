using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquila.Data
{
    /// <summary>
    /// Represents a running game
    /// </summary>
    class Game
    {
        public string Name { get; set; }
        public List<Player> Players { get; set; }
        public GameState State { get; set; }
        public Dictionary<GameState, Func<GameState, string, object>> Transitions { get; protected set; }

        public Game(string name)
        {
            Name = name;
        }

        public enum GameState
        {
            Lobby = 0,
        }
    }
}
