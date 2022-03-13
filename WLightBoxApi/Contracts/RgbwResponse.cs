using Newtonsoft.Json;
using WLightBoxApi.Models;

namespace WLightBoxApi.Contracts
{
    /// <summary>
    /// Model for Json Contract. Used in GET /api/rgbw/state Api
    /// </summary>
    public class RgbwResponse
    {
        [JsonProperty("rgbw")]
        public Rgbw Rgbw { get; set; }
    }
}
