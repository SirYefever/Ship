using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ship.ShipParts
{

    
    public class ChestClass : BountyContainer
    {
        public int Gold { get; set; }
        public ChestClass()
        {
            Gold = 0;
        }
    }
}
