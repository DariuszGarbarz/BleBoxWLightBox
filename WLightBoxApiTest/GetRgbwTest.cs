using Microsoft.VisualStudio.TestTools.UnitTesting;
using WLightBoxApi.Contracts;
using WLightBoxApi.WebServices;

namespace WLightBoxApiTest
{
    [TestClass]
    public class GetRgbwTest
    {
        [TestMethod]
        public void GetRgbwFromApiTest()
        {
            //arrange
            var expected = new RgbwResponse()
            {
                rgbw = new WLightBoxApi.Models.Rgbw()
                {
                    colorMode = 1,
                    effectID = 5,
                    desiredColor = "ffff300000",
                    currentColor = "ffff300000",
                    lastOnColor = "ffff300000",
                    durationsMs = new WLightBoxApi.Models.DurationsMs()
                    {
                        colorFade = 500,
                        effectFade = 3000,
                        effectStep = 60000
                    }
                }
            };

            var getRgbw = new GetRgbw(Settings.mockServerAdress, Settings.httpClient);

            //act

            var actual = getRgbw.GetRgbwFromApi().Result;

            //assert

            Assert.AreEqual(expected.rgbw.colorMode, actual.rgbw.colorMode);
            Assert.AreEqual(expected.rgbw.effectID, actual.rgbw.effectID);
            Assert.AreEqual(expected.rgbw.desiredColor, actual.rgbw.desiredColor);
            Assert.AreEqual(expected.rgbw.currentColor, actual.rgbw.currentColor);
            Assert.AreEqual(expected.rgbw.lastOnColor, actual.rgbw.lastOnColor);
            Assert.AreEqual(expected.rgbw.durationsMs.colorFade, actual.rgbw.durationsMs.colorFade);
            Assert.AreEqual(expected.rgbw.durationsMs.effectFade, actual.rgbw.durationsMs.effectFade);
            Assert.AreEqual(expected.rgbw.durationsMs.effectStep, actual.rgbw.durationsMs.effectStep);


        }
    }
}
