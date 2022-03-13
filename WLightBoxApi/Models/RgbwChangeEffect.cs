using Newtonsoft.Json;

namespace WLightBoxApi.Models
{
    public class RgbwChangeEffect
    {
        [JsonProperty("effectID")]
        public int EffectID { get; set; }
        [JsonProperty("durationsMs")]
        public DurationsMsChangeEffect DurationsMs { get; set; }
    }
}
