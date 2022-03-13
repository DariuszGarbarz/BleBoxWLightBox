using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<RgbwResponse> PostRgbwChangeEffectToApi()
        {
            RgbwChangeEffectRequest rgbwContract = new RgbwChangeEffectRequest();
            rgbwContract.Rgbw = new RgbwChangeEffect();
            rgbwContract.Rgbw.DurationsMs = new DurationsMsChangeEffect();

            rgbwContract.Rgbw.DurationsMs.EffectFade = _effectFade;
            rgbwContract.Rgbw.DurationsMs.EffectStep = _effectStep;
            rgbwContract.Rgbw.EffectID = _effectId;

            var uri = new Uri($"{_protocol}{_ipAdress}{_postRgbw}");

            return await PostService<RgbwResponse, RgbwChangeEffectRequest>(uri, rgbwContract);
        }
    }
}
