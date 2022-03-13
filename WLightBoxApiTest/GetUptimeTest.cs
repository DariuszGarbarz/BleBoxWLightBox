using Microsoft.VisualStudio.TestTools.UnitTesting;
using WLightBoxApi.Contracts;
using WLightBoxApi.WebServices;

namespace WLightBoxApiTest
{
    [TestClass]
    public class GetUptimeTest
    {
        [TestMethod]
        public void GetUptimeFromApiTest()
        {
            //arrange
            var expected = new UptimeResponse()
            {
                UpTimeS = 11111
            };

            var getUptime = new GetUptime(Settings.mockServerAdress, Settings.httpClient);

            //act

            var actual = getUptime.GetUptimeFromApi().Result;

            //assert

            Assert.AreEqual(expected.UpTimeS, actual.UpTimeS);
        }
    }
}
