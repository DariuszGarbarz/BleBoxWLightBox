using Newtonsoft.Json;

namespace WLightBoxApi.Models
{
    public class DurationsMs
    {
        [JsonProperty("colorFade")]
        public int ColorFade { get; set; }
        [JsonProperty("effectFade")]
        public int EffectFade { get; set; }
        [JsonProperty("effectStep")]
        public int EffectStep { get; set; }
    }
}
