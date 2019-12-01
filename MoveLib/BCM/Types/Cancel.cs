namespace MoveLib.BCM.Types
{
    public class Cancel
    {
        public string Name { get; set; }
        public short Index { get; set; }
        public int ScriptIndex { get; set; }
        public CancelInts CancelInts { get; set; }
        public byte[] UnknownBytes { get; set; }
    }
}
