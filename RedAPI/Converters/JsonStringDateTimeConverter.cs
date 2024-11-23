using System.Globalization;
using System.Text.Json.Serialization;
using System.Text.Json;

public class JsonStringDateTimeConverter : JsonConverter<DateTime?>
{
    private readonly string[] _formats = {
        "yyyy-MM-dd HH:mm:ss",
        "yyyy-MM-dd'T'HH:mm:ss",
        "yyyy-MM-dd HH:mm:ss.fff",
        "yyyy-MM-dd'T'HH:mm:ss.fff'Z'"  // Añadido el formato con Z
    };

    public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        Console.WriteLine($"Valor recibido para deserializar: {value}");

        if (reader.TokenType == JsonTokenType.String)
        {
            if (DateTime.TryParseExact(value, _formats, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out var date))
            {
                return date;
            }

            if (DateTime.TryParse(value, null, DateTimeStyles.AssumeUniversal, out var isoDate))
            {
                return isoDate;
            }
        }

        if (reader.TokenType == JsonTokenType.Null)
        {
            return null;
        }

        throw new JsonException($"Fecha no válida: {value}");
    }

    public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value?.ToString("yyyy-MM-dd HH:mm:ss"));
    }
}
