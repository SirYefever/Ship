

namespace Ship.ShipParts
{
    public class TreasureRoom : Storage
    {

        public int Gold { get => chest.Gold; }
        public int Slaves { get => slaveRoom.SlavesQuantity; }
        public int Bounty { get => Gold + Slaves; }
        public TreasureRoom(int capacity) : base(capacity)
        {

        }

        public ChestClass chest {  get; set; }
        public SlaveRoomClass slaveRoom { get; set; }



    }
}
