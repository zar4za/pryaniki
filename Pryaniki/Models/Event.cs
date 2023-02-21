using System.Text.Json.Serialization;

namespace Pryaniki.Models
{
    public class Event
    {
        [JsonIgnore]
        public int Id { get; init; }

        [JsonPropertyName("name")]
        public string Name { get; init; } = null!;

        [JsonPropertyName("value")]
        public int Value { get; init; }

        [JsonIgnore]
        public DateTime DateTime { get; set; }
    }
}
