using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using WLightBoxApi.Models;

namespace WLightBoxApi.WebServices
{
    public class GetUptime : ApiCommunication
    {
        public GetUptime(string ipAdress) : base(ipAdress)
        {

        }

        public UptimeModel GetUptimeFromApi()
        {
            _httpClient = new HttpClient();
            var uri = new Uri($"https://{_ipAdress}/api/device/uptime");

            HttpResponseMessage response = _httpClient.GetAsync(uri).Result;
            var getResultsJson = response.Content.ReadAsStringAsync().Result;

            var uptimeResult = JsonConvert.DeserializeObject<UptimeModel>(getResultsJson);

            return uptimeResult;
        }
    }
}
