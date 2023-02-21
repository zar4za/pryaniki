using System.Text.Json.Serialization;

namespace Pryaniki.Models
{
    public class Event
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        [JsonPropertyName("value")]
        public int Value { get; set; }

        [JsonIgnore]
        public DateTime DateTime { get; set; }
    }
}
