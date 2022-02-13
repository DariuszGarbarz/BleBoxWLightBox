using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using WLightBoxApi.Models;

namespace WLightBoxApi.WebServices
{
    public class GetRgbw : ApiCommunication
    {
        public GetRgbw(string ipAdress) : base(ipAdress)
        {

        }

        public RgbwModel GetRgbwFromApi()
        {
            _httpClient = new HttpClient();
            var uri = new Uri($"https://{_ipAdress}/api/rgbw/state");

            HttpResponseMessage response = _httpClient.GetAsync(uri).Result;
            var getResultsJson = response.Content.ReadAsStringAsync().Result;

            var rgbwResult = JsonConvert.DeserializeObject<RgbwModel>(getResultsJson);

            return rgbwResult;
        }
    }
}
