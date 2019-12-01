namespace MoveLib.BAC.Types
{
    public class VisualEffect
    {
        public int TickStart { get; set; }
        public int TickEnd { get; set; }
        public int BACVERint1 { get; set; }
        public int BACVERint2 { get; set; }
        public int BACVERint3 { get; set; }
        public int BACVERint4 { get; set; }

        public short Unknown1 { get; set; }
        public short Unknown2 { get; set; }
        public short Unknown3 { get; set; }

        public short EffectId { get; set; }
        private short Type { set => EffectId = value; }

        public short Unknown5 { get; set; }
        public short AttachPoint { get; set; }

        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public int Unknown10 { get; set; }
        public float Size { get; set; }
        public float Unknown12 { get; set; }
    }
}
