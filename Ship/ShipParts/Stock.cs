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
        
        public int Capacity { get; private set ; }  
        public Stock(int capacity) : base(capacity)
        {
            Capacity = capacity;
        }

        public int Food { get => _provisionsQuantity; }
        public int Ammo { get => _ammoQuantity; }

        public void IncreaseAmmoQuantity()
        {
            if (_provisionsQuantity + _ammoQuantity < Capacity )
                _ammoQuantity++;
        }

        public void IncreaseFoodQuantity()
        {
            if (_provisionsQuantity + _ammoQuantity < Capacity)
                _provisionsQuantity++;
        }
    }
}
