using WLightBoxApi.Models;

namespace WLightBoxApi.Contracts
{
    /// <summary>
    /// Model for Json Contract. Used in GET /info Api
    /// </summary>
    public class DeviceResponse
    {
        public Device device { get; set; }
    }
}
