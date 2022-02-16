using Newtonsoft.Json;
using System;
using System.Net.Http;
using WLightBoxApi.Contracts;

namespace WLightBoxApi.WebServices
{
    /// <summary>
    /// Class that connects to device /api/device/uptime Api and gets uptime status data
    /// </summary>
    public class GetUptime : ApiCommunication
    {
        public GetUptime(string ipAdress, HttpClient httpClient) : base(ipAdress, httpClient)
        {

        }

        public UptimeResponse GetUptimeFromApi()
        {
            
            var uri = new Uri($"https://{_ipAdress}/api/device/uptime");

            HttpResponseMessage response = _httpClient.GetAsync(uri).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Communication Error");
            }

            var getResultsJson = response.Content.ReadAsStringAsync().Result;

            var uptimeResult = JsonConvert.DeserializeObject<UptimeResponse>(getResultsJson);

            return uptimeResult;
        }
    }
}
