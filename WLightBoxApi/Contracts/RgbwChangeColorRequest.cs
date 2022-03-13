using Newtonsoft.Json;
using WLightBoxApi.Models;

namespace WLightBoxApi.Contracts
{
    /// <summary>
    /// Model for Json Contract. Used in POST /api/rgbw/set Api
    /// </summary>
    public class RgbwChangeColorRequest
    {
        [JsonProperty("rgbw")]
        public RgbwChangeColor Rgbw { get; set; }
    }
}
