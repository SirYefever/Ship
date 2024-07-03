using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ship
{
    public abstract class Storage : ShipPart
    {
        private int _capacity;

        public Storage(int capacity)
        {
            _capacity = capacity;
        }       
    }
}
