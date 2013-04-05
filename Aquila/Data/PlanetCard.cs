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

        public virtual bool Equals(PlanetCard obj)
        {
            return obj.PlanetName == PlanetName;
        }

        public virtual bool Equals(BonusCard obj)
        {
            return true;
        }
    }
}
