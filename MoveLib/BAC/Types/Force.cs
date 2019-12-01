using MoveLib.Util;
using Newtonsoft.Json;


namespace MoveLib.BAC.Types
{
    public class Force
    {
        public int TickStart { get; set; }
        public int TickEnd { get; set; }
        public int BACVERint1 { get; set; }
        public int BACVERint2 { get; set; }
        public int BACVERint3 { get; set; }
        public int BACVERint4 { get; set; }

        public float Amount { get; set; }
        [JsonProperty("Flag")]
        [JsonConverter(typeof(ForceEnumConverter))]
        public int Flag { get; set; }
    }
}
