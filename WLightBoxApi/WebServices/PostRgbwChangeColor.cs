using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using WLightBoxApi.Contracts;
using WLightBoxApi.Models;

namespace WLightBoxApi.WebServices
{
    public class PostRgbwChangeColor : ApiCommunication
    {
        
        private string _desiredColor;
        private int _colorFade;

        public PostRgbwChangeColor(string ipAdress, HttpClient httpClient, string desiredColor, int colorFade) : base(ipAdress, httpClient)
        {
            _desiredColor = desiredColor;
            _colorFade = colorFade;
        }

        public RgbwResponse PostRgbwChangeColorToApi()
        {
            RgbwChangeColorRequest rgbwContract = new RgbwChangeColorRequest();

            rgbwContract.rgbw = new RgbwChangeColor();
            rgbwContract.rgbw.durationsMs = new DurationsMsChangeColor();

            rgbwContract.rgbw.desiredColor = _desiredColor;
            rgbwContract.rgbw.durationsMs.colorFade = _colorFade;

            var uri = new Uri($"https://{_ipAdress}/api/rgbw/set");

            var rgbwPost = JsonConvert.SerializeObject(rgbwContract);

            HttpResponseMessage response = _httpClient.PostAsync(uri, new StringContent(rgbwPost, Encoding.UTF8, "application/json")).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Communication Error");
            }
            var getResultsJson = response.Content.ReadAsStringAsync().Result;

            var rgbwResult = JsonConvert.DeserializeObject<RgbwResponse>(getResultsJson);

            return rgbwResult;


        }

    }
}
