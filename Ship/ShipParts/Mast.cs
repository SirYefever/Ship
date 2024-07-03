
namespace Ship.ShipParts
{
    public class Mast : ShipPart
    {
        public CrowsNest crowsNest { get; set; }
        public bool CrowsNestNeeded { get; set; } = true; //TODO fix

        public Mast()
        {
            if (CrowsNestNeeded)
                crowsNest = new CrowsNest();
        }
    }
}
