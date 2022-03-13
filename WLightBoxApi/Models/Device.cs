using Newtonsoft.Json;

namespace WLightBoxApi.Models
{
    public class Device
    {
        [JsonProperty("deviceName")]
        public string DeviceName { get; set; }
        [JsonProperty("product")]
        public string Product { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("apiLevel")]
        public string ApiLevel { get; set; }
        [JsonProperty("hv")]
        public string Hv { get; set; }
        [JsonProperty("fv")]
        public string Fv { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("ip")]
        public string Ip { get; set; }
    }
}
