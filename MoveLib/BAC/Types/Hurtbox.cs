using MoveLib.Util;
using Newtonsoft.Json;

namespace MoveLib.BAC.Types
{
    public class Hurtbox
    {
        public int TickStart { get; set; }
        public int TickEnd { get; set; }
        public int BACVERint1 { get; set; }
        public int BACVERint2 { get; set; }
        public int BACVERint3 { get; set; }
        public int BACVERint4 { get; set; }

        public float X { get; set; }
        [JsonConverter(typeof(NegativeZeroConverter))]
        public float Y { get; set; } // Can be -0.0; I'd like to preserve the sign.
        public float Z { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }

        public int Unknown1 { get; set; }

        public short Unknown2 { get; set; } // Usually 25 (0x19)
        public short Unknown3 { get; set; } // Usually 25 (0x19)
        public short Unknown4 { get; set; } // Usually 25 (0x19)

        public short Unknown5 { get; set; }

        public short Unknown6 { get; set; } // Invincibility Type [Flag?]   (0=none, 1=stand, 2=crouch, 3=stand+crouch, 4=air, 5=full)
        public short Unknown7 { get; set; } // Parry Type?
        public short Unknown8 { get; set; } // TWO PARTS - Armor Group & Armor Priority
        public short Unknown9 { get; set; } // Armor Count (# of hits)

        public byte Flag1 { get; set; }
        public byte Flag2 { get; set; }
        public byte Flag3 { get; set; }
        public byte Flag4 { get; set; }

        public short HitEffect { get; set; }
        public short Unknown10 { get; set; }
        public int Unknown11 { get; set; }

        public float Unknown12 { get; set; }
        public int Unknown13 { get; set; }
    }
}
