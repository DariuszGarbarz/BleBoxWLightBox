using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using WLightBoxApi.Contracts;
using WLightBoxApi.Models;

namespace WLightBoxApi.WebServices
{
    public class GetRgbw : ApiCommunication
    {
        public GetRgbw(string ipAdress, HttpClient httpClient) : base(ipAdress, httpClient)
        {

        }

        public RgbwContract GetRgbwFromApi()
        {
            
            var uri = new Uri($"https://{_ipAdress}/api/rgbw/state");

            HttpResponseMessage response = _httpClient.GetAsync(uri).Result;
            // obsługa błędów, sprawdzić response
            if (!response.IsSuccessStatusCode)
            {
                //exception
            }
            var getResultsJson = response.Content.ReadAsStringAsync().Result;

            var rgbwResult = JsonConvert.DeserializeObject<RgbwContract>(getResultsJson);

            return rgbwResult;
        }
    }
}
