using System.Net.Http;

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

    }
}
