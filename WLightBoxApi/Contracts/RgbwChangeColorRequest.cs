using System;
using System.Collections.Generic;
using System.Text;
using WLightBoxApi.Models;

namespace WLightBoxApi.Contracts
{
    /// <summary>
    /// Model for Json Contract. Used in POST /api/rgbw/set Api
    /// </summary>
    public class RgbwChangeColorRequest
    {
        public RgbwChangeColor rgbw { get; set; }
    }
}
