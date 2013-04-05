using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Aquila.Data
{
    class Player
    {
        public Color Color { get; set; }
        public int SpaceShipDevelopment { get; set; }
        public int TechnologyDevelopment { get; set; }

        public int TransportCards { get; set; }
        public List<PlanetCard> Hand { get; set; }

        public int PlayerTradeableCards
        {
            get
            {
                return TechnologyDevelopment > 0 ? 4 : 3;
            }
        }

        public int DeckTradeableCards
        {
            get
            {
                return TechnologyDevelopment > 1 ? 3 : 2;
            }
        }

        public bool roundDown
        {
            get
            {
                return TechnologyDevelopment > 2;
            }
        }

        public int maxCards
        {
            get
            {
                switch (SpaceShipDevelopment)
                {
                    case 1:
                        return 10;
                    case 2:
                        return 11;
                    case 3:
                        return 13;
                    default:
                        return 9;
                }
            }
        }
    }
}
