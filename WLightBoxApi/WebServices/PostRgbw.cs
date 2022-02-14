using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using WLightBoxApi.Contracts;
using WLightBoxApi.Models;

namespace WLightBoxApi.WebServices
{
    public class PostRgbw : ApiCommunication
    {
        private RgbwContract _rgbw;
        public PostRgbw(string ipAdress, RgbwContract rgbw, HttpClient httpClient) : base(ipAdress, httpClient)
        {
            _rgbw = rgbw;
        }

        public RgbwContract PostRgbwToApi()
        {
            _httpClient = new HttpClient();
            var uri = new Uri($"https://{_ipAdress}/api/rgbw/set");

            var rgbwPost = JsonConvert.SerializeObject(_rgbw);

            HttpResponseMessage response = _httpClient.PostAsync(uri, new StringContent(rgbwPost, Encoding.UTF8, "application/json")).Result;
            var getResultsJson = response.Content.ReadAsStringAsync().Result;

            var rgbwResult = JsonConvert.DeserializeObject<RgbwContract>(getResultsJson);

            return rgbwResult;


        }
    }
}
