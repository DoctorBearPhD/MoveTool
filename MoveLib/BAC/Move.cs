using MoveLib.BAC.Types;

namespace MoveLib.BAC
{
    public class Move
    {
        public string Name { get; set; }
        public int Index { get; set; }
        public int FirstHitboxFrame { get; set; }
        public int LastHitboxFrame { get; set; }
        public int InterruptFrame { get; set; }
        public int TotalTicks { get; set; }

        public int ReturnToOriginalPosition { get; set; }

        public float XSpeedMultiplier { get; set; }
        private float Slide { set => XSpeedMultiplier = value; }

        public float YSpeedMultiplier { get; set; }
        private float unk3 { set => YSpeedMultiplier = value; }

        public float ZSpeedMultiplier { get; set; }
        private float unk4 { set => ZSpeedMultiplier = value; }

        public float XAcceleration { get; set; }
        public float YAcceleration { get; set; }
        public float ZAcceleration { get; set; }

        private float unk5 { set => XAcceleration = value; }
        private float unk6 { set => YAcceleration = value; }
        private float unk7 { set => ZAcceleration = value; }

        public int Flag { get; set; }
        public int unk9 { get; set; }

        public int numberOfTypes { get; set; }

        public int unk13 { get; set; }
        public int HeaderSize { get; set; }


        public short Unknown12 { get; set; } // Projectile GFX 1
        public short Unknown13 { get; set; } // Projectile GFX 2

        public short Unknown14 { get; set; } // ???

        public short Unknown15 { get; set; } // Projectile Hit Ground GFX 1
        public short Unknown16 { get; set; } // Projectile Hit Ground GFX 2

        public short Unknown17 { get; set; } // ???

        public float Unknown18 { get; set; } // Projectile Size
        public short Unknown19 { get; set; } // Projectile Hit Ground SFX

        public short Unknown20 { get; set; } // ???

        public short Unknown21 { get; set; } // ???
        public short Unknown22 { get; set; } // ???


        public AutoCancel[] AutoCancels { get; set; }
        public Type1[] Type1s { get; set; }
        public Force[] Forces { get; set; }
        public Cancel[] Cancels { get; set; }
        public Other[] Others { get; set; } //projectiles
        public Hitbox[] Hitboxes { get; set; }
        public Hurtbox[] Hurtboxes { get; set; }
        public PhysicsBox[] PhysicsBoxes { get; set; }
        public Animation[] Animations { get; set; }
        public Type9[] Type9s { get; set; }
        public SoundEffect[] SoundEffects{ get; set; }
        public VisualEffect[] VisualEffects { get; set; }
        public Position[] Positions { get; set; }
    }
}
