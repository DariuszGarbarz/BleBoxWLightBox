using System;
using System.Collections.Generic;
using System.Text;

namespace WLightBoxApi.Contracts
{
    /// <summary>
    /// Model for Json input and output. Used in GET /api/device/uptime Api
    /// </summary>
    public class UptimeResponse
    {
        public int upTimeS { get; set; }
    }

}
