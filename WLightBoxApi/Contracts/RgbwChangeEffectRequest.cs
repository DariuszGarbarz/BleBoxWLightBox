using Newtonsoft.Json;
using WLightBoxApi.Models;

namespace WLightBoxApi.Contracts
{
    /// <summary>
    /// Model for Json Contract. Used in POST /api/rgbw/set Api
    /// </summary>
    public class RgbwChangeEffectRequest
    {
        [JsonProperty("rgbw")]
        public RgbwChangeEffect Rgbw { get; set; }
    }
}
