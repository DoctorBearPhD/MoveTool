using MoveLib.BAC.Enums;

namespace MoveLib.BAC.Types
{
    public class Animation
    {
        public int TickStart { get; set; }
        public int TickEnd { get; set; }
        public int BACVERint1 { get; set; }
        public int BACVERint2 { get; set; }
        public int BACVERint3 { get; set; }
        public int BACVERint4 { get; set; }

        public short Index { get; set; }
        [Newtonsoft.Json.JsonConverter(typeof(Util.MoveLibEnumConverter))]
        public AnimationEnum Type { get; set; }
        public short FrameStart { get; set; }
        public short FrameEnd { get; set; }

        public int Unknown1 { get; set; }
        public int Unknown2 { get; set; }
    }
}
