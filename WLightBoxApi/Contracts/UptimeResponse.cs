using Newtonsoft.Json;

namespace WLightBoxApi.Contracts
{
    /// <summary>
    /// Model for Json Contract. Used in GET /api/device/uptime Api
    /// </summary>
    public class UptimeResponse
    {
        [JsonProperty("upTimeS")]
        public int UpTimeS { get; set; }
    }

}
