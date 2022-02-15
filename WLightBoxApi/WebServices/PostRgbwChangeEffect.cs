using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using WLightBoxApi.Contracts;
using WLightBoxApi.Models;

namespace WLightBoxApi.WebServices
{
    /// <summary>
    /// Class that connects to device /api/rgbw/set Api, posting new effects settings to device and getting State of Lightning data
    /// </summary>
    public class PostRgbwChangeEffect : ApiCommunication
    {
        private int _effectFade;
        private int _effectStep;
        private int _effectId;
        public PostRgbwChangeEffect(string ipAdress, HttpClient httpClient, int effectFade, int effectStep, int effectId) : base(ipAdress, httpClient)
        {
            _effectFade = effectFade;
            _effectStep = effectStep;
            _effectId = effectId;
        }

        public RgbwResponse PostRgbwChangeEffectToApi()
        {

            RgbwChangeEffectRequest rgbwContract = new RgbwChangeEffectRequest();
            rgbwContract.rgbw = new RgbwChangeEffect();
            rgbwContract.rgbw.durationsMs = new DurationsMsChangeEffect();

            rgbwContract.rgbw.durationsMs.effectFade = _effectFade;
            rgbwContract.rgbw.durationsMs.effectStep = _effectStep;
            rgbwContract.rgbw.effectID = _effectId;

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
