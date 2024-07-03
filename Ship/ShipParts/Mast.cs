
namespace Ship.ShipParts
{
    public class Mast : ShipPart
    {
        public CrowsNest crowsNest { get; set; }

        public Mast(bool crowsNestRequired)
        {
            if (crowsNestRequired)
                crowsNest = new CrowsNest();
        }
    }
}
