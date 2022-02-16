using WLightBoxApi.Models;

namespace WLightBoxApi.Contracts
{
    /// <summary>
    /// Model for Json Contract. Used in POST /api/rgbw/set Api
    /// </summary>
    public class RgbwChangeEffectRequest
    {
        public RgbwChangeEffect rgbw { get; set; }
    }
}
