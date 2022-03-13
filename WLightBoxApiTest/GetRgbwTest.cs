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
                Rgbw = new WLightBoxApi.Models.Rgbw()
                {
                    ColorMode = 1,
                    EffectID = 5,
                    DesiredColor = "ffff300000",
                    CurrentColor = "ffff300000",
                    LastOnColor = "ffff300000",
                    DurationsMs = new WLightBoxApi.Models.DurationsMs()
                    {
                        ColorFade = 500,
                        EffectFade = 3000,
                        EffectStep = 60000
                    }
                }
            };

            var getRgbw = new GetRgbw(Settings.mockServerAdress, Settings.httpClient);

            //act

            var actual = getRgbw.GetRgbwFromApi().Result;

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
