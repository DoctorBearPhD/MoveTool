using System;
namespace MoveLib.BCM.Types
{
    [Flags]
    public enum InputFlags
    {
        Neutral = 0, //???
        Up = 1,
        Down = 2,
        Back = 4,
        Forward = 8,
    }
}
