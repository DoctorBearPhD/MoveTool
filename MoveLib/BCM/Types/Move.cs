namespace MoveLib.BCM.Types
{
    public class Move
    {
        public byte Offset { get; set; }
        public short Index { get; set; }
        public string Name { get; set; }
        public short Input { get; set; }
        public short InputFlags { get; set; }
        public int PositionRestriction { get; set; }
        public int Unknown3 { get; set; }
        public float RestrictionDistance { get; set; }
        public int Unknown4 { get; set; }
        // CHANGED: ProjectileLimit split into 2 parts
        public short ProjectileGroup { get; set; }
        public short ProjectileMaxCount { get; set; }

        private int ProjectileLimit
        {
            set
            {
                ProjectileGroup = (short)(value & 0x00FF >> 0);
                ProjectileMaxCount = (short)(value & 0xFF00 >> 8);
            }
        }

        // ---
        public short Unknown6 { get; set; }
        public short Unknown7 { get; set; }
        public short Unknown8 { get; set; }
        public short Unknown9 { get; set; }
        public short MeterRequirement { get; set; }
        public short MeterUsed { get; set; }
        public short Unknown10 { get; set; }
        public short Unknown11 { get; set; }
        public short VtriggerRequirement { get; set; }
        public short VtriggerUsed { get; set; }
        public int Unknown16 { get; set; }
        public short InputMotionIndex { get; set; }
        public short ScriptIndex { get; set; }

        public int Unknown17 { get; set; }
        public int Unknown18 { get; set; }
        public int Unknown19 { get; set; }
        public float Unknown20 { get; set; }
        public float Unknown21 { get; set; }

        public int Unknown22 { get; set; }
        public int Unknown23 { get; set; }
        public int Unknown24 { get; set; }
        public int Unknown25 { get; set; }

        public short Unknown26 { get; set; }
        public short NormalOrVtrigger { get; set; }

        public int Unknown28 { get; set; }
    }
}
