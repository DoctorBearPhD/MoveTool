using MoveLib.BAC.Enums;
using MoveLib.BAC.Types;
using MoveLib.BCM.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;

namespace MoveLib.Util
{
    public class MoveLibEnumConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            switch (value)
            {
                case AnimationEnum anim:
                    serializer.Serialize(writer, anim);
                    break;

                case InputPropertiesFlags ipf:
                    serializer.Serialize(writer, ipf);
                    break;

                default:
                    Console.WriteLine($"Unknown type found while trying to write enum to JSON.");
                    Console.WriteLine($"Search resulting JSON file for \"!UNKNOWN!\".");
                    serializer.Serialize(writer, "!UNKNOWN!");
                    break;

                case null:
                    Console.WriteLine($"WARNING - NULL ENUM. Search resulting JSON file for \"!NULL!\".");
                    serializer.Serialize(writer, "!NULL!");
                    //throw new ArgumentNullException(nameof(value));
                    break;
            }
        
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                switch (reader.TokenType)
                {
                    case JsonToken.String:

                        //Debug.WriteLine($"\"{reader.Value}\" of type \"{reader.TokenType}\" found. Attempting conversion...");

                        var enumText = reader.Value.ToString();
                        dynamic convertedStr = -1;

                        switch (existingValue)
                        {
                            case AnimationEnum anim:
                                if (enumText == "Regular")
                                    enumText = AnimationEnum.UNIQUE_OBJECT.ToString();
                                else if (enumText == "Face")
                                    enumText = AnimationEnum.UNIQUE_FACIAL.ToString();

                                convertedStr = (short)Enum.Parse(typeof(AnimationEnum), enumText);
                                break;

                            case InputPropertiesFlags ipf:
                                convertedStr = (short)Enum.Parse(typeof(InputPropertiesFlags), enumText);
                                break;

                            default:
                                var errMsg = "Error converting an enum during read operation: Unknown type!";
                                Console.WriteLine(errMsg);
                                throw new Exception(errMsg);
                        }

                        //Debug.WriteLine($"\tConverted \"{reader.Value}\" to \"{convertedStr}\"");

                        return convertedStr;

                    case JsonToken.Integer:
                        
                        switch (existingValue)
                        {
                            case AnimationEnum anim:
                                return (AnimationEnum)short.Parse(reader.Value.ToString());

                            case InputPropertiesFlags ipf:
                                return (InputPropertiesFlags)short.Parse(reader.Value.ToString());

                            default:
                                throw new ArgumentException();
                        }
                }
            }
            catch (Exception ex)
            {
                throw new JsonSerializationException($"Error converting value {reader.Value} to type '{objectType}'.", ex);
            }

            throw new JsonReaderException($"{nameof(Force.Flag)} was not of type {JTokenType.String} nor {JTokenType.Integer}!");
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(InputPropertiesFlags) || 
                   objectType == typeof(AnimationEnum);
        }
    }
}
