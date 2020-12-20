using Newtonsoft.Json;

namespace HealthCloud.Lib.Calculations.Responses
{
    internal class MetabolismResponse
    {
        [JsonProperty("result")]
        public double Result { get; set; }
    }
}
