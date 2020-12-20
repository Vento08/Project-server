namespace HealthCloud.Web.Models.Calculations
{
    public class CaloriesData
    {
        public int Activity { get; set; }
        public int Age { get; set; }
        public int Gender { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }

        public double GetMultiplier()
        {
            if (Activity == 0)
            {
                return 1.2;
            }
            else if (Activity == 1)
            {
                return 1.375;
            }
            else if (Activity == 2)
            {
                return 1.55;
            }
            else if (Activity == 3)
            {
                return 1.725;
            }
            else if (Activity == 4)
            {
                return 1.9;
            }
            return 0;
        }
    }
}