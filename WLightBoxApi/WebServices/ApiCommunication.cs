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
        /// URL or ipAdress of the device we want to interact with
        /// </summary>
        /// <param name="ipAdress">string without https:// ex: 192.168.1.11</param>
        public ApiCommunication(string ipAdress)
        {
            _ipAdress = ipAdress;
        }

    }
}
