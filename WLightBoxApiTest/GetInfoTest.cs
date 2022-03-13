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
                Device = new WLightBoxApi.Models.Device()
                {
                    DeviceName = "Postman Test",
                    Product = "wLightBox_test",
                    Type = "wLightBoxTest",
                    ApiLevel = "20200518",
                    Hv = "9.9test",
                    Fv = "1.1test",
                    Id = "g650e32d2217",
                    Ip = "192.168.1.11"
                }
            };

            var getInfo = new GetInfo(Settings.mockServerAdress, Settings.httpClient);

            //act

            var actual = getInfo.GetInfoFromApi().Result;

            //assert

            Assert.AreEqual(expected.Device.DeviceName, actual.Device.DeviceName);
            Assert.AreEqual(expected.Device.Product, actual.Device.Product);
            Assert.AreEqual(expected.Device.Type, actual.Device.Type);
            Assert.AreEqual(expected.Device.ApiLevel, actual.Device.ApiLevel);
            Assert.AreEqual(expected.Device.Hv, actual.Device.Hv);
            Assert.AreEqual(expected.Device.Fv, actual.Device.Fv);
            Assert.AreEqual(expected.Device.Id, actual.Device.Id);
            Assert.AreEqual(expected.Device.Ip, actual.Device.Ip);

        }
    }
}
