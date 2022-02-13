using System;
using System.Collections.Generic;
using System.Text;

namespace WLightBoxApi.Models
{
    /// <summary>
    /// Model for Json input and output. Used in GET /api/device/uptime Api
    /// </summary>
    public class UptimeModel
    {
        public int upTimeS { get; set; }
    }

}
