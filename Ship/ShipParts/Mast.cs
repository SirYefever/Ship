using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ship.ShipParts
{
    public class Mast : ShipPart
    {
        public CrowsNest crowsNest { get; set; }

        public Mast()
        {
            crowsNest = new CrowsNest();
        }
    }
}
