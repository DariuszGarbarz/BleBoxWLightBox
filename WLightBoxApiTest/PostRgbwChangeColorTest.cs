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
                Rgbw = new WLightBoxApi.Models.Rgbw()
                {
                    ColorMode = 1,
                    EffectID = 3,
                    DesiredColor = "00ff300000",
                    CurrentColor = "00ff300000",
                    LastOnColor = "00ff300000",
                    DurationsMs = new WLightBoxApi.Models.DurationsMs()
                    {
                        ColorFade = 25000,
                        EffectFade = 20000,
                        EffectStep = 15000
                    }
                }
            };

            var postRgbwChangeColor = new PostRgbwChangeColor(Settings.mockServerAdress, Settings.httpClient, desiredColor, colorFade);

            //act

            var actual = postRgbwChangeColor.PostRgbwChangeColorToApi().Result;

            //assert

            Assert.AreEqual(expected.Rgbw.ColorMode, actual.Rgbw.ColorMode);
            Assert.AreEqual(expected.Rgbw.EffectID, actual.Rgbw.EffectID);
            Assert.AreEqual(expected.Rgbw.DesiredColor, actual.Rgbw.DesiredColor);
            Assert.AreEqual(expected.Rgbw.CurrentColor, actual.Rgbw.CurrentColor);
            Assert.AreEqual(expected.Rgbw.LastOnColor, actual.Rgbw.LastOnColor);
            Assert.AreEqual(expected.Rgbw.DurationsMs.ColorFade, actual.Rgbw.DurationsMs.ColorFade);
            Assert.AreEqual(expected.Rgbw.DurationsMs.EffectFade, actual.Rgbw.DurationsMs.EffectFade);
            Assert.AreEqual(expected.Rgbw.DurationsMs.EffectStep, actual.Rgbw.DurationsMs.EffectStep);

        }
    }
}