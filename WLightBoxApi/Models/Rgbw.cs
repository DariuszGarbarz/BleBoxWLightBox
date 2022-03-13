using Newtonsoft.Json;

namespace WLightBoxApi.Models
{
    public class Rgbw
    {
        [JsonProperty("colorMode")]
        public int ColorMode { get; set; }
        [JsonProperty("effectID")]
        public int EffectID { get; set; }
        [JsonProperty("desiredColor")]
        public string DesiredColor { get; set; }
        [JsonProperty("currentColor")]
        public string CurrentColor { get; set; }
        [JsonProperty("lastOnColor")]
        public string LastOnColor { get; set; }
        [JsonProperty("durationsMs")]
        public DurationsMs DurationsMs { get; set; }
    }
}
