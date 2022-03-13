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
    /// Class that connects to device /api/rgbw/set Api, posting new color settings to device and getting State of Lightning data
    /// </summary>
    public class PostRgbwChangeColor : ApiCommunication
    {
        
        private string _desiredColor;
        private int _colorFade;

        public PostRgbwChangeColor(string ipAdress, HttpClient httpClient, string desiredColor, int colorFade) : base(ipAdress, httpClient)
        {
            _desiredColor = desiredColor;
            _colorFade = colorFade;
        }

        public async Task<RgbwResponse> PostRgbwChangeColorToApi()
        {
            RgbwChangeColorRequest rgbwContract = new RgbwChangeColorRequest();
            rgbwContract.Rgbw = new RgbwChangeColor();
            rgbwContract.Rgbw.DurationsMs = new DurationsMsChangeColor();
            rgbwContract.Rgbw.DesiredColor = _desiredColor;
            rgbwContract.Rgbw.DurationsMs.ColorFade = _colorFade;

            var uri = new Uri($"{_protocol}{_ipAdress}{_postRgbw}");

            return await PostService<RgbwResponse, RgbwChangeColorRequest>(uri, rgbwContract);
        }
    }
}
