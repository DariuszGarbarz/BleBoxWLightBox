using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WLightBoxApi.Contracts;

namespace WLightBoxApi.WebServices
{
    /// <summary>
    /// Class that connects to device /api/device/uptime Api and gets uptime status data
    /// </summary>
    public class GetUptime : ApiCommunication
    {
        public GetUptime(string ipAdress, HttpClient httpClient) : base(ipAdress, httpClient)
        {

        }

        public async Task<UptimeResponse> GetUptimeFromApi()
        {
            var uri = new Uri($"{_protocol}{_ipAdress}{_getUptime}");

            return await GetService<UptimeResponse>(uri);
        }
    }
}
