using System.Net.Http;

namespace WLightBoxApiTest
{
    internal static class Settings
    {
        internal const string mockServerAdress = "465311c3-b289-4cbd-b7e3-2d626c54bfeb.mock.pstmn.io/192.168.1.11";
        internal static HttpClient httpClient = new HttpClient();
    }
}
