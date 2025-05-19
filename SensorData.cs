using System.Text.Json.Serialization;

namespace MobileApp;

public class SensorData
{
    [JsonPropertyName("Влажность")]
    public double Humidity { get; set; }

    [JsonPropertyName("Температура")]
    public double Temperature { get; set; }
}