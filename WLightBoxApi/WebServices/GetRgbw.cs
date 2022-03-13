using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WLightBoxApi.Contracts;

namespace WLightBoxApi.WebServices
{
    /// <summary>
    /// Class thats connects to device /api/rgbw/state and gets all State of Lightning data
    /// </summary>
    public class GetRgbw : ApiCommunication
    {
        public GetRgbw(string ipAdress, HttpClient httpClient) : base(ipAdress, httpClient)
        {

        }

        public async Task<RgbwResponse> GetRgbwFromApi()
        {           
            var uri = new Uri($"{_protocol}{_ipAdress}{_getRgbw}");

            return await GetService<RgbwResponse>(uri);

            //HttpResponseMessage response = await _httpClient.GetAsync(uri);
            //if (!response.IsSuccessStatusCode)
            //{
            //    throw new Exception("Communication Error");
            //}
            //var getResultsJson = response.Content.ReadAsStringAsync().Result;

            //var rgbwResult = JsonConvert.DeserializeObject<RgbwResponse>(getResultsJson);

            //return rgbwResult;
        }
    }
}
