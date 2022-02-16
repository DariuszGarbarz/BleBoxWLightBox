using Microsoft.VisualStudio.TestTools.UnitTesting;
using WLightBoxApi.Contracts;
using WLightBoxApi.WebServices;

namespace WLightBoxApiTest
{
    [TestClass]
    public class PostRgbwChangeColorTest
    {
        [TestMethod]
        public void PostRgbwChangeColorToApiTest()
        {
            //arrange
            string desiredColor = "00ff300000";
            int colorFade = 25000;

            var expected = new RgbwResponse()
            {
                rgbw = new WLightBoxApi.Models.Rgbw()
                {
                    colorMode = 1,
                    effectID = 3,
                    desiredColor = "00ff300000",
                    currentColor = "00ff300000",
                    lastOnColor = "00ff300000",
                    durationsMs = new WLightBoxApi.Models.DurationsMs()
                    {
                        colorFade = 25000,
                        effectFade = 20000,
                        effectStep = 15000
                    }
                }
            };

            var postRgbwChangeColor = new PostRgbwChangeColor(Settings.mockServerAdress, Settings.httpClient, desiredColor, colorFade);

            //act

            var actual = postRgbwChangeColor.PostRgbwChangeColorToApi().Result;

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