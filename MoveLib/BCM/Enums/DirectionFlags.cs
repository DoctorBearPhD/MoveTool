using System;

namespace MoveLib.BCM.Enums
{
    [Flags]
    public enum DirectionFlags : short
    {
        Neutral = 0, //???
        Up = 1,
        Down = 2,
        Back = 4,
        Forward = 8
    }
}
