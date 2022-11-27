using System.Text.Json;
using System.Text.Json.Serialization;

namespace BuyMe.Presentation.JsonConverters
{
    public sealed class NullableDateOnlyJsonConverter : JsonConverter<DateOnly?>
    {
        public override DateOnly? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TryGetDateTime(out DateTime dateTime))
                return DateOnly.FromDateTime(dateTime);
            else
                return null;
        }

        public override void Write(Utf8JsonWriter writer, DateOnly? value, JsonSerializerOptions options)
        {
            if (value == null)
                writer.WriteNullValue();
            else
                writer.WriteStringValue(((DateOnly)value).ToString("O"));
        }
    }

}
