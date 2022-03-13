using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WLightBoxApi.WebServices
{
    /// <summary>
    /// Base class for api communication classes
    /// </summary>
    public abstract class ApiCommunication
    {
        protected HttpClient _httpClient;
        protected string _ipAdress;

        /// <summary>
        /// URL or ipAdress of the device we want to interact with + Previously crated httpclient for all api communication
        /// </summary>
        /// <param name="ipAdress">string without https:// ex: 192.168.1.11</param>
        /// <param name="httpClient">httpclient created from HttpClientSetup Class</param>
        public ApiCommunication(string ipAdress, HttpClient httpClient)
        {
            _ipAdress = ipAdress;
            _httpClient = httpClient;            
        }

        protected string _contractType = "application/json";
        protected string _protocol = "http://";
        protected string _getInfo = "/info";
        protected string _getRgbw = "/api/rgbw/state";
        protected string _getUptime = "/api/device/uptime";
        protected string _postRgbw = "/api/rgbw/set";
        protected Encoding _encoding = Encoding.UTF8;

        public async Task<T> GetService<T>(Uri uri)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(uri);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Communication Error");
            }
            var getResultsJson = await response.Content.ReadAsStringAsync();
            var deserializeResult = JsonConvert.DeserializeObject<T>(getResultsJson);

            return deserializeResult;
        }

        public async Task<T> PostService<T, W>(Uri uri, W rgbwContract)
        {
            var rgbwPost = JsonConvert.SerializeObject(rgbwContract);
            HttpResponseMessage response = await _httpClient.PostAsync(uri, new StringContent(rgbwPost, _encoding, _contractType));
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Communication Error");
            }
            var getResultsJson = await response.Content.ReadAsStringAsync();
            var rgbwResult = JsonConvert.DeserializeObject<T>(getResultsJson);

            return rgbwResult;
        }
    }
}
