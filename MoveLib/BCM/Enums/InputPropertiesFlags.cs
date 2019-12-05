using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveLib.BCM.Enums
{
    [Flags]
    public enum InputPropertiesFlags : short
    {
        LenientMatching = 1,
        ExactMatching = 2,
        // 4 = Unused
        // 8 = Unused
        AnyButtons = 16,
        AllButtons = 32,
        TwoButtons = 48,
        // 64  = Unused
        // 128 = Unused
        Unknown1 = 256,
        EnableDirectionMatching = 512, // Enable direction matching?
        Unknown3 = 1024,
        Unknown4 = 2048,
        PositiveEdge = 4096,
        NoPlink = 8192, // Plink prevention? Changes HitType to THROW
        NegativeEdge = 16384
    }
}
