namespace HealthCloud.Lib.Calculations
{
    public class CaloriesInformation
    {
        /// <summary>
        /// Ideal amount of calories to keep weight as it is
        /// </summary>
        public double Ideal { get; internal set; }
        /// <summary>
        /// Minimal amount of colories to lose weight
        /// </summary>
        public double Loss { get; internal set; }
    }
}
