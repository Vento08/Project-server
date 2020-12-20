using Newtonsoft.Json;

namespace HealthCloud.Lib.Calculations.Responses
{
    internal class WeightResponse
    {
        [JsonProperty("result")]
        public double Result { get; set; }
    }
}
