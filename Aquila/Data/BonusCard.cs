using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquila.Data
{
    class BonusCard : PlanetCard
    {
        public int Points { get; set; }

        public override bool Equals(BonusCard obj)
        {
            return obj.Points == Points;
        }

        public override bool Equals(PlanetCard obj)
        {
            return true;
        }
    }
}
