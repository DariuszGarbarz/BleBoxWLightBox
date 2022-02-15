using System;
using System.Collections.Generic;
using System.Text;
using WLightBoxApi.Models;

namespace WLightBoxApi.Contracts
{
    /// <summary>
    /// Model for Json input and output. Used in GET /api/rgbw/state Api and POST /api/rgbw/set Api
    /// </summary>
    public class RgbwResponse
    {
        public Rgbw rgbw { get; set; }

    }
}
