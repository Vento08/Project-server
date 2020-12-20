using Newtonsoft.Json;

namespace HealthCloud.Lib.Products
{
    /// <summary>
    /// Represents Product (Food)
    /// </summary>
    public class Product
    {
        /// <summary>
        /// How much calories in 100g of <see cref="Product"/>
        /// </summary>
        [JsonProperty("calories")]
        public double Calories { get; set; }

        /// <summary>
        /// How much carbons in 100g of <see cref="Product"/>
        /// </summary>
        [JsonProperty("carbons")]
        public double Carbons { get; set; }

        /// <summary>
        /// How much fats in 100g of <see cref="Product"/>
        /// </summary>
        [JsonProperty("fats")]
        public double Fats { get; set; }

        /// <summary>
        /// Name of product
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// How much proteins in 100g of <see cref="Product"/>
        /// </summary>
        [JsonProperty("proteins")]
        public double Proteins { get; set; }

        public override string ToString()
        {
            return $"Product: {Name}. Calories: {Calories}, Fats: {Fats}, Carbons: {Carbons}, Proteins: {Proteins}";
        }
    }
}