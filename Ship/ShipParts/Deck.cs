using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ship.ShipParts
{
    public class Deck : ShipPart
    {
        public Cabin cabin {  get; set; }
        public Mast mast { get; set; } 
        public Galley galley { get; set; }
        public TreasureRoom treasureRoom { get; set; }
        public Stock stock { get; set; }

        public Deck(int chestCapacity, int stockCapacity, bool crowsNestRequired)
        {
            cabin = new Cabin();
            mast = new Mast(crowsNestRequired);
            treasureRoom = new TreasureRoom(chestCapacity);  
            stock = new Stock(stockCapacity);
            galley = new Galley();
        }
    }
}
