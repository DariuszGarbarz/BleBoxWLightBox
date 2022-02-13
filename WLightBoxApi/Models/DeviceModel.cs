using System;
using System.Collections.Generic;
using System.Text;

namespace WLightBoxApi.Models
{
    /// <summary>
    /// Model for Json input and output. Used in GET /info Api
    /// </summary>
    public class DeviceModel
    {
        public Device device { get; set; }
    }

    public class Device
    {
        public string deviceName { get; set; }
        public string product { get; set; }
        public string type { get; set; }
        public string apiLevel { get; set; }
        public string hv { get; set; }
        public string fv { get; set; }
        public string id { get; set; }
        public string ip { get; set; }
    }
}
