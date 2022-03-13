using Newtonsoft.Json;

namespace WLightBoxApi.Models
{
    public class RgbwChangeColor
    {
        [JsonProperty("desiredColor")]
        public string DesiredColor { get; set; }
        [JsonProperty("durationsMs")]
        public DurationsMsChangeColor DurationsMs { get; set; }
    }
}
