using System;
using System.Collections.Generic;
using System.Text;
using WLightBoxApi.Models;

namespace WLightBoxApi.Contracts
{
    /// <summary>
    /// Model for Json input and output. Used in GET /info Api
    /// </summary>
    public class DeviceResponse
    {
        public Device device { get; set; }
    }
}
