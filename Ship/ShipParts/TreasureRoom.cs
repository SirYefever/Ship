using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ship.ShipParts
{
    public class TreasureRoom : Storage
    {
        public ChestClass chest {  get; set; }
        public SlaveRoomClass slaveRoom { get; set; }

    }
}
