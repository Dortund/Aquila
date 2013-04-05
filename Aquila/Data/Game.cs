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
        public Deck<PlanetCard> Deck { get; set; }

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

        private Deck<PlanetCard> CreatePlanetDeck()
        {
            Deck<PlanetCard> Deck = new Deck<PlanetCard>();
            for (int i = 0; i < Planets.Count; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    switch (i)
                    {
                        case 0:
                            Deck.Add(new PlanetCard() { PlanetName = "help" });
                            break;
                        case 1:
                            Deck.Add(new PlanetCard() { PlanetName = "i'm" });
                            break;
                        case 2:
                            Deck.Add(new PlanetCard() { PlanetName = "trapped" });
                            break;
                        case 3:
                            Deck.Add(new PlanetCard() { PlanetName = "in" });
                            break;
                        case 4:
                            Deck.Add(new PlanetCard() { PlanetName = "a" });
                            break;
                        case 5:
                            Deck.Add(new PlanetCard() { PlanetName = "game" });
                            break;
                        case 6:
                            Deck.Add(new PlanetCard() { PlanetName = "factory" });
                            break;
                    }
                }
            }
            Deck.AutoShuffle = true;
            Deck.Shuffle();
            return Deck;
        }

        public void Setup()
        {
            if (Players.Count < 3 || Players.Count > 5)
                throw new InvalidOperationException();

            Deck = this.CreatePlanetDeck();

            foreach (var p in Players)
            {
                p.TransportCards = 2;

                var cards = 0;
                switch (Players.Count)
                {
                    case 3:
                        cards = 6;
                        break;
                    case 4:
                        cards = 9;
                        break;
                    case 5:
                        cards = 6;
                        break;
                }
                for (int i = 0; i < cards; i++)
                {
                    var card = Deck.Draw();
                    

                    Deck.Discard(card);
                }
                    
            }
        }

        public enum GameState
        {
            Lobby = 0,
        }
    }
}
