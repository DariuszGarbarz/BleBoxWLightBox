using System;
using System.Collections.Generic;
using System.Text;

namespace WLightBoxApi.Contracts
{
    /// <summary>
    /// Model for Json Contract. Used in GET /api/device/uptime Api
    /// </summary>
    public class UptimeResponse
    {
        public int upTimeS { get; set; }
    }

}
