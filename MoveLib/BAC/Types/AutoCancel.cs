namespace MoveLib.BAC.Types
{
    public class AutoCancel
    {
        public int TickStart { get; set; }
        public int TickEnd { get; set; }
        public int BACVERint1 { get; set; }
        public int BACVERint2 { get; set; }
        public int BACVERint3 { get; set; }
        public int BACVERint4 { get; set; }


        public AutoCancelCondition Condition { get; set; }
        public short MoveIndex { get; set; }
        public string MoveIndexName { get; set; }

        public short ScriptStartTime { get; set; }
        private short Unknown1 { set => ScriptStartTime = value; }

        public short NumberOfInts { get; set; }

        public int Unknown2 { get; set; } // Something to do with SkillID
        public int Unknown3 { get; set; } // if Unknown2 is 24, this value is the Skill ID used for trials

        public int Unknown4 { get; set; }

        public int Offset { get; set; }

        public int[] Ints { get; set; }
    }
}
