
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Ship.ShipParts
{
    public class ShipClass : ShipPart
    {
        public Deck deck { get; set; }
        private int _cannonQuantity;
        private string _condition;
        private bool _isAnyShipPartBurning;
        public ShipClass(int cannonsQuantity, int chestCapacity, int stockCapacity, bool crowsNestRequired)
        {
            _cannonQuantity = cannonsQuantity;
            _condition = "Intact";
            _isAnyShipPartBurning = false;
            deck = new Deck(chestCapacity, stockCapacity, crowsNestRequired);  
        }

        public bool IsAnyShipPartBurning
        {
            get => _isAnyShipPartBurning;
            set => _isAnyShipPartBurning = value;
        }

        public string CrewSize
        {
            get
            {
                if (deck.mast.crowsNest == null)
                    return (Crewers.Count +
                        deck.Crewers.Count +
                        deck.cabin.Crewers.Count +
                        deck.mast.Crewers.Count +
                        deck.galley.Crewers.Count +
                        deck.treasureRoom.Crewers.Count +
                        deck.stock.Crewers.Count).ToString() + " Человек";
                else
                {
                    return (Crewers.Count +
                        deck.Crewers.Count +
                        deck.cabin.Crewers.Count +
                        deck.mast.Crewers.Count +
                        deck.mast.crowsNest.Crewers.Count +
                        deck.galley.Crewers.Count +
                        deck.treasureRoom.Crewers.Count +
                        deck.stock.Crewers.Count).ToString() + " Человек";
                }
            }
        }

        public string CannonsQuantityString
        {
            get
            {
                return _cannonQuantity.ToString() + " штук";
            }
        }

        public string BurningStringStatus
        {
            get
            {
                if (IsBurning)
                    return "Пожар";
                else
                    return "Нормуль";
            }
        }

        public void IncreaseCannonsQuantity()
        {
            _cannonQuantity++;
            
        }

        public void DecreaseCannonsQuantity()
        {
            _cannonQuantity--;
        }

        public void Sail()
        {

        }
    }
}
