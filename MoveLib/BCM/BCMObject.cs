using MoveLib.BCM.Types;

namespace MoveLib.BCM
{
    public class BCMObject
    {
        public Charge[] Charges { get; set; }
        public Input[] Inputs { get; set; }
        public Move[] Moves { get; set; }
        public CancelList[] CancelLists { get; set; }
        public byte[] RawUassetHeaderDontTouch { get; set; }
    }
}
