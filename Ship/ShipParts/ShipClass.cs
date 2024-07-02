
namespace Ship.ShipParts
{
    public class ShipClass : ShipPart
    {
        public Deck deck { get; set; }
        private int _cannonQuantity;
        private string _condition;
        public ShipClass(int cannonsQuantity)
        {
            _cannonQuantity = cannonsQuantity;
            _condition = "Intact";
            deck = new Deck();  
        }

        public void Sail()
        {

        }
    }
}
