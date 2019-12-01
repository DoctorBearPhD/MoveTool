using System;
namespace MoveLib.BCM.Types
{
    [Flags]
    public enum InputDirection
    {
        Neutral = 0, //???
        Up = 1,
        Down = 2,
        Back = 4,
        Forward = 8,
    }
}
