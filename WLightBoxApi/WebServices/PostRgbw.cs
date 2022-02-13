using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using WLightBoxApi.Models;

namespace WLightBoxApi.WebServices
{
    public class PostRgbw : ApiCommunication
    {
        private RgbwModel _rgbw;
        public PostRgbw(string ipAdress, RgbwModel rgbw) : base(ipAdress)
        {
            _rgbw = rgbw;
        }

        public RgbwModel PostRgbwToApi()
        {
            _httpClient = new HttpClient();
            var uri = new Uri($"https://{_ipAdress}/api/rgbw/set");

            var rgbwPost = JsonConvert.SerializeObject(_rgbw);

            HttpResponseMessage response = _httpClient.PostAsync(uri, new StringContent(rgbwPost, Encoding.UTF8, "application/json")).Result;
            var getResultsJson = response.Content.ReadAsStringAsync().Result;

            var rgbwResult = JsonConvert.DeserializeObject<RgbwModel>(getResultsJson);

            return rgbwResult;


        }
    }
}
