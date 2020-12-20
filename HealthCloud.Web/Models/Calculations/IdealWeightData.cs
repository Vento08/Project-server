namespace HealthCloud.Web.Models.Calculations
{
    public class IdealWeightData
    {
        public int Age { get; set; }
        public int BodyType { get; set; }
        public double Height { get; set; }

        public double GetBodyTypeMultiplier()
        {
            if (BodyType == 0)
            {
                return 0.9;
            }
            else if (BodyType == 1)
            {
                return 1.1;
            }
            else
            {
                return 1;
            }
        }
    }
}