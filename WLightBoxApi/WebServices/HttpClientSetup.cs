﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace WLightBoxApi.WebServices
{
    /// <summary>
    /// Class for httpClient setup. Could be needed for future autenthication addition.
    /// </summary>
    public static class HttpClientSetup
    {
        
        public static HttpClient CreateHttpClient()
        {
            HttpClient httpClient = new HttpClient();
            return httpClient;
        }
    }
}
