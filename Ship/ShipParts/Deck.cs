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

        public Deck()
        {
            cabin = new Cabin();
            mast = new Mast();
            treasureRoom = new TreasureRoom();  
            stock = new Stock();
            galley = new Galley();
        }
    }
}
