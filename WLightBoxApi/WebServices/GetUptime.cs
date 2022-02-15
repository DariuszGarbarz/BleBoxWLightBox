using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using WLightBoxApi.Contracts;
using WLightBoxApi.Models;

namespace WLightBoxApi.WebServices
{
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
