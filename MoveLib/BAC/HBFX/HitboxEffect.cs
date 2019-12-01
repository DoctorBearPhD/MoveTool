namespace MoveLib.BAC.HBFX
{
    public class HitboxEffect
    {
        public short Type { get; set; }
        public short Index { get; set; }
        public int DamageType { get; set; }
        public byte Unused1 { get; set; }       //
        public byte NumberOfType1 { get; set; } // Flags?
        public byte NumberOfType2 { get; set; } //
        public byte Unused2 { get; set; }       //
        public short Damage { get; set; }
        public short Stun { get; set; }

        public int Index9 { get; set; } //0?
        public short EXBuildAttacker { get; set; }
        public short EXBuildDefender { get; set; }
        public int Index12 { get; set; } //0?
        public int HitStunFramesAttacker { get; set; }

        public short HitStunFramesDefender { get; set; }
        public short FuzzyEffect { get; set; }
        public short RecoveryAnimationFramesDefender { get; set; }
        public short Index17 { get; set; }
        public short Index18 { get; set; }
        public short Index19 { get; set; }
        public float KnockBack { get; set; }

        public float FallSpeed { get; set; }
        public int Index22 { get; set; } //0?
        public int Index23 { get; set; } //0?
        public int Index24 { get; set; } //0?

        public int Index25 { get; set; } //0?
        public int OffsetToStartOfType1 { get; set; }
        public int OffsetToStartOfType2 { get; set; }

        public HitboxEffectSoundEffect[] Type1s { get; set; }
        public HitboxEffectVisualEffect[] Type2s { get; set; }
    }
}
