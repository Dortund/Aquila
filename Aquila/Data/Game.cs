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
        public List<Player> Players { get; set; }
        public GameState State { get; set; }
        public Dictionary<GameState, Func<GameState, string, object>> Transitions { get; protected set; }

        public enum GameState
        {
            Lobby = 0,
        }
    }
}
