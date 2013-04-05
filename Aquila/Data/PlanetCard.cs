using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquila.Data
{
    class PlanetCard
    {
        public string PlanetName { get; set; }

        public bool Equals(PlanetCard obj)
        {
            return obj.PlanetName == PlanetName;
        }

        public bool Equals(BonusCard obj)
        {
            return true;
        }
    }
}
