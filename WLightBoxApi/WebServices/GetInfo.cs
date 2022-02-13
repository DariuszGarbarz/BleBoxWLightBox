using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using WLightBoxApi.Models;

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
        public GetInfo(string ipAdress) : base(ipAdress)
        {

        }

        /// <summary>
        /// Gets general information about device
        /// </summary>
        /// <returns>Complete DeviceModel</returns>
        public DeviceModel GetInfoFromApi()
        {
            _httpClient = new HttpClient();
            var uri = new Uri($"https://{_ipAdress}/info");

            HttpResponseMessage response = _httpClient.GetAsync(uri).Result;
            var getResultsJson = response.Content.ReadAsStringAsync().Result;

            var deviceResult = JsonConvert.DeserializeObject<DeviceModel>(getResultsJson);

            return deviceResult;
        }

    }
}
