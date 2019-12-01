namespace MoveLib.BAC.Types
{
    public class Other //Projectiles and other BACeff stuff.
    {
        public int TickStart { get; set; }
        public int TickEnd { get; set; }
        public int BACVERint1 { get; set; }
        public int BACVERint2 { get; set; }
        public int BACVERint3 { get; set; }
        public int BACVERint4 { get; set; }

        public int Unknown1 { get; set; }
        public short Unknown2 { get; set; }
        public short NumberOfInts { get; set; }
        public int Offset { get; set; }

        public int[] Ints { get; set; }
    }
}
