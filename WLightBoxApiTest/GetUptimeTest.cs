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
                upTimeS = 11111
            };

            var getUptime = new GetUptime(Settings.mockServerAdress, Settings.httpClient);

            //act

            var actual = getUptime.GetUptimeFromApi();

            //assert

            Assert.AreEqual(expected.upTimeS, actual.upTimeS);
        }
    }
}
