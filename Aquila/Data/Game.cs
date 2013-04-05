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
        public List<Planet> Planets { get; set; }

        public Game(string name)
        {
            Name = name;

            Planets = new List<Planet>(){
                new Planet(new int[] { 8, 6, 4}),
                new Planet(new int[] { 10, 8, 6 }),
                new Planet(new int[] { 12, 10, 8 }),
                new Planet(new int[] { 12, 10, 8 }),
                new Planet(new int[] { 14, 12, 10 }),
                new Planet(new int[] { 10, 8, 6 }),
                new Planet(new int[] { 8, 6, 4 }),
            };
        }

        public enum GameState
        {
            Lobby = 0,
        }
    }
}
