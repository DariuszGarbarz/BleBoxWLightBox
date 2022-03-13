using Newtonsoft.Json;
using WLightBoxApi.Models;

namespace WLightBoxApi.Contracts
{
    /// <summary>
    /// Model for Json Contract. Used in GET /info Api
    /// </summary>
    public class DeviceResponse
    {
        [JsonProperty("device")]
        public Device Device { get; set; }
    }
}
