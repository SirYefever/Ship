using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ship.ShipParts
{
    public class Stock : Storage
    {
        private int _provisionsQuantity;
        private int _ammoQuantity;

        public Stock(int capacity) : base(capacity)
        {
        }

        public int Food { get => _provisionsQuantity; }
        public int Ammo { get => _ammoQuantity; }
    }
}
