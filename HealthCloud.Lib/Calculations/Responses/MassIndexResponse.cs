using Newtonsoft.Json;

namespace HealthCloud.Lib.Calculations.Responses
{
    internal class MassIndexResponse
    {
        [JsonProperty("result")]
        public double Result { get; set; }
        [JsonProperty("condition")]
        public int Condition { get; set; }
    }
}
