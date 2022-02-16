using Microsoft.VisualStudio.TestTools.UnitTesting;
using WLightBoxApi.Contracts;
using WLightBoxApi.WebServices;

namespace WLightBoxApiTest
{
    [TestClass]
    public class GetInfoTest
    {
        [TestMethod]
        public void GetInfoFromApiTest()
        {
            //arrange

            var expected = new DeviceResponse()
            {
                device = new WLightBoxApi.Models.Device()
                {
                    deviceName = "Postman Test",
                    product = "wLightBox_test",
                    type = "wLightBoxTest",
                    apiLevel = "20200518",
                    hv = "9.9test",
                    fv = "1.1test",
                    id = "g650e32d2217",
                    ip = "192.168.1.11"
                }
            };

            var getInfo = new GetInfo(Settings.mockServerAdress, Settings.httpClient);

            //act

            var actual = getInfo.GetInfoFromApi().Result;

            //assert

            Assert.AreEqual(expected.device.deviceName, actual.device.deviceName);
            Assert.AreEqual(expected.device.product, actual.device.product);
            Assert.AreEqual(expected.device.type, actual.device.type);
            Assert.AreEqual(expected.device.apiLevel, actual.device.apiLevel);
            Assert.AreEqual(expected.device.hv, actual.device.hv);
            Assert.AreEqual(expected.device.fv, actual.device.fv);
            Assert.AreEqual(expected.device.id, actual.device.id);
            Assert.AreEqual(expected.device.ip, actual.device.ip);

        }
    }
}
