using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace HealthCloud.Lib.Calculations.Responses
{
    internal class CaloriesResponse
    {
        [JsonProperty("loss")]
        public double Loss { get; set; }
        [JsonProperty("result")]
        public double Result { get; set; }
    }
}
