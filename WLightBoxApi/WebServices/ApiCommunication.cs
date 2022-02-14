using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace WLightBoxApi.WebServices
{
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
