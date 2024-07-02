using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ship.ShipParts
{
    public class TreasureRoom : Storage
    {
        public Chest chest {  get; set; }
        public SlaveRoom slaveRoom { get; set; }

    }
}
