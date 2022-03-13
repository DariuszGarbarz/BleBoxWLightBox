using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WLightBoxApi.Contracts;

namespace WLightBoxApi.WebServices
{
    /// <summary>
    /// class that gets all the basic info about our device from GET /info Api
    /// </summary>
    public class GetInfo : ApiCommunication
    {
        /// <summary>
        /// URL or ipAdress of the device we want to interact with
        /// </summary>
        /// <param name="ipAdress">string without https:// ex: 192.168.1.11</param>
        public GetInfo(string ipAdress, HttpClient httpClient) : base(ipAdress, httpClient)
        {

        }

        /// <summary>
        /// Gets general information about device
        /// </summary>
        /// <returns>Complete DeviceModel</returns>
        public async Task<DeviceResponse> GetInfoFromApi()
        {
            var uri = new Uri($"{_protocol}{_ipAdress}{_getInfo}");

            return await GetService<DeviceResponse>(uri);
        }
    }
}
