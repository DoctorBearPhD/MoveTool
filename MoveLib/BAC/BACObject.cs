using MoveLib.BAC.HBFX;

namespace MoveLib.BAC
{
    public class BACObject
    {
        public MoveList[] MoveLists { get; set; }
        public HitboxEffects[] HitboxEffectses { get; set; }
        public byte[] RawUassetHeaderDontTouch { get; set; }
        public short BACVER { get; set; }

        public short MoveListCount;
        public short HitboxFxCount;
    }
}
