namespace MoveLib.BCM.Types
{
    public class InputPart
    {
        public short Buffer { get; set; }
        public InputType InputType { get; set; }
        public InputFlags InputDirection { get; set; }
        public short Unknown1 { get; set; }
        public short Unknown2 { get; set; }
        public short Unknown3 { get; set; }
        public short Unknown4 { get; set; }
        public short Unknown5 { get; set; }
    }
}
