using System;
using System.Diagnostics;
using MoveLib.BAC;
using MoveLib.BAC.Enums;
using MoveLib.BAC.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace MoveLib.Util
{
    public class ForceEnumConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, (ForceEnum)value);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                switch (reader.TokenType)
                {
                    case JsonToken.String:

                        Debug.WriteLine($"\"{reader.Value}\" of type \"{reader.TokenType}\" found. Attempting conversion...");

                        var enumText = reader.Value.ToString();
                        var convertedStr = (int)Enum.Parse(typeof(ForceEnum), enumText);

                        Debug.WriteLine($"\tConverted \"{reader.Value}\" to {convertedStr}");

                        return convertedStr;

                    case JsonToken.Integer:
                        var convertedInt = Convert.ChangeType(reader.Value, objectType);

                        return convertedInt;
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
            return objectType == typeof(ForceEnum);
        }
    }
}
