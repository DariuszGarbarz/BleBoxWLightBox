using System;
using System.Collections.Generic;
using System.Text;

namespace WLightBoxApi.Models
{
    /// <summary>
    /// Model for Json input and output. Used in GET /api/rgbw/state Api and POST /api/rgbw/set Api
    /// </summary>
    public class RgbwModel
    {
        public Rgbw rgbw { get; set; }

    }
    public class DurationsMs
    {
        public int colorFade { get; set; }
        public int effectFade { get; set; }
        public int effectStep { get; set; }
    }

    public class Rgbw
    {
        public int colorMode { get; set; }
        public int effectID { get; set; }
        public string desiredColor { get; set; }
        public string currentColor { get; set; }
        public string lastOnColor { get; set; }
        public DurationsMs durationsMs { get; set; }
    }
}
