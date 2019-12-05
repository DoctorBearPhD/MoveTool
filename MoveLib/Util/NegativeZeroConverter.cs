using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveLib.Util
{
    /// <summary>
    /// Preserves negative sign on zeroes when converting to/from JSON.
    /// </summary>
    public class NegativeZeroConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(float);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                switch (reader.TokenType)
                {
                    case JsonToken.String:
                        string s = (string)reader.Value;
                        float theFloat = float.Parse(s); // float.Parse() cannot return a negative zero, so we have to work around it...
                        if (theFloat == 0f && s.StartsWith("-"))
                            theFloat = -0.0f;

                        return theFloat;

                    case JsonToken.Float:
                        // so weird... 
                        //   reader.Value is "boxed", so we can't directly cast it to float. 
                        //   Instead we cast the boxed value to double, and then cast that to float.
                        return (float)((double)reader.Value); 

                    default:
                        System.Diagnostics.Debug.WriteLine($"Unknown value type. Type was: {reader.TokenType}");
                        throw new ArgumentException();
                }
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine("!!WARNING!! NegativeZeroConverter failed to read the value as a float! " +
                    $"value: \"{existingValue.ToString()}\"");
                return reader.Value;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            try
            {
                float theFloat = (float)value;

                if (theFloat == 0f && (1 / theFloat) < 0)
                    serializer.Serialize(writer, "-0.0"); // the float is -0, preserve the sign by writing it as a string
                else
                    serializer.Serialize(writer, theFloat);
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine($"!!WARNING!! NegativeZeroConverter failed to write the float! value: {value.ToString()}");
            }
        }
    }
}
