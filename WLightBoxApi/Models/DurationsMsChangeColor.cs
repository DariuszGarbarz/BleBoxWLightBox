using Newtonsoft.Json;

namespace WLightBoxApi.Models
{
    public class DurationsMsChangeColor
    {
        [JsonProperty("colorFade")]
        public int ColorFade { get; set; }
    }
}
