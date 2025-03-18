

namespace Ship.ShipParts
{
    public class TreasureRoom : Storage
    {
        public int Capacity { get; private set; }
        public int Gold { get => chest.Gold; }
        public int Slaves { get => slaveRoom.SlavesQuantity; }
        public int Bounty { get => Gold + Slaves; }
        public TreasureRoom(int capacity) : base(capacity)
        {
            Capacity = capacity;
        }

        public ChestClass chest {  get; set; }
        public SlaveRoomClass slaveRoom { get; set; }

        public void IncreaseSlavesQuantity()
        {
            if (Bounty < Capacity)
                slaveRoom.SlavesQuantity++;
        }

        public void IncreaseGoldQuantity()
        {
            if (Bounty < Capacity)
                chest.Gold++;
        }
    }
}
