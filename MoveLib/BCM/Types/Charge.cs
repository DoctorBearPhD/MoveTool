using MoveLib.BCM.Enums;

namespace MoveLib.BCM.Types
{
    public class Charge
    {
       public int Index { get; set; }
       public DirectionFlags ChargeDirection { get; set; }
       public short ChargeFrames { get; set; }
       public short Unknown1 { get; set; }
       public short Unknown2 { get; set; }
       public short Unknown3 { get; set; }
       public short Flags { get; set; }
       public short ChargeIndex { get; set; }
       public short Unknown4 { get; set; }
    }
}
