namespace MoveLib.BAC.Types
{
    public class Position
    {
        public int TickStart { get; set; }
        public int TickEnd { get; set; }
        public int BACVERint1 { get; set; }
        public int BACVERint2 { get; set; }
        public int BACVERint3 { get; set; }
        public int BACVERint4 { get; set; }

        public float Movement { get; set; }
        public int Flag { get; set; }
    }
}
