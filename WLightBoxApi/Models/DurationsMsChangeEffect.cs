using Newtonsoft.Json;

namespace WLightBoxApi.Models
{
    public class DurationsMsChangeEffect
    {
        [JsonProperty("effectFade")]
        public int EffectFade { get; set; }
        [JsonProperty("effectStep")]
        public int EffectStep { get; set; }
    }
}
