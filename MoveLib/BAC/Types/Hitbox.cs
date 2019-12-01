﻿namespace MoveLib.BAC.Types
{
    public class Hitbox
    {
        public int TickStart { get; set; }
        public int TickEnd { get; set; }
        public int BACVERint1 { get; set; }
        public int BACVERint2 { get; set; }
        public int BACVERint3 { get; set; }
        public int BACVERint4 { get; set; }

        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }

        public int Unknown1 { get; set; }

        public short Unknown2 { get; set; }
        public short Unknown3 { get; set; }
        public short Unknown4 { get; set; }
        public short Unknown5 { get; set; }

        public short Unknown6 { get; set; }
        public short Unknown7 { get; set; }
        public short Unknown8 { get; set; }
        public short NumberOfHits { get; set; }

        public byte HitType { get; set; }
        public byte JuggleLimit { get; set; }
        public byte JuggleIncrease { get; set; }
        public byte Flag4 { get; set; }

        public short HitboxEffectIndex { get; set; }
        public short Unknown10 { get; set; }
        public int Unknown11 { get; set; }
        public int Unknown12 { get; set; }
    }
}
