using System;
using Newtonsoft.Json;

namespace HealthCloud.Lib.Calculations
{
    internal class BodyTypeResponse
    {
        [JsonProperty("bodyType")]
        public int BodyType { get; set; }
    }
}
