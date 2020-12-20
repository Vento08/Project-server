using System.Collections.Generic;
using System.IO;
using System.Net;

using Newtonsoft.Json;

using HealthCloud.Lib.Calculations.Responses;

namespace HealthCloud.Lib.Calculations
{
    /// <summary>
    /// Wrapper over Calctulations API of HealthCloud
    /// </summary>
    public sealed class CalculationsApi
    {
        internal const string ApiPath = "http://healthapp-kurswork.herokuapp.com/api/calculations/";

        public CalculationsApi()
        {
        }

        private T GetResponse<T>(string request, KeyValuePair<string, string>[] parameters) where T : class
        {
            string path = ApiPath + request;
            //Building path
            if(parameters != null &&parameters.Length > 0)
            {
                path += "?";
                for(int i = 0; i < parameters.Length; i++)
                {
                    path += $"{parameters[i].Key.ToLower()}={parameters[i].Value}";
                    if(i != parameters.Length - 1)
                    {
                        path += "&";
                    }
                }
            }

            //Creating HTTP request
            HttpWebRequest webRequest = WebRequest.CreateHttp(path);
            webRequest.Method = "GET";

            //Getting HTTP request
            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();

            T result;

            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                //Parsing JSON response into an Object
                string json = reader.ReadToEnd();
                result = JsonConvert.DeserializeObject<T>(json);
            }

            return result;
        }

        public CaloriesInformation GetCalories(int activity, int age, int gender, double height, double weight)
        {
            KeyValuePair<string, string>[] parameters = new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("activity", activity.ToString()),
                new KeyValuePair<string, string>("age", age.ToString()),
                new KeyValuePair<string, string>("gender", gender.ToString()),
                new KeyValuePair<string, string>("height", height.ToString("F0")),
                new KeyValuePair<string, string>("weight", weight.ToString("F0"))
            };

            CaloriesResponse response = GetResponse<CaloriesResponse>("calories", parameters);

            return new CaloriesInformation { Ideal = response.Result, Loss = response.Loss };
        }

        public BodyMassIndexInformation GetMassIndex(double height, double weight, int bodytype)
        {
            KeyValuePair<string, string>[] parameters = new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("bodytype", bodytype.ToString()),
                new KeyValuePair<string, string>("height", height.ToString("F0")),
                new KeyValuePair<string, string>("weight", weight.ToString("F0"))
            };

            MassIndexResponse response = GetResponse<MassIndexResponse>("bmi", parameters);

            return new BodyMassIndexInformation
            {
                MassIndex = response.Condition,
                Value = response.Result
            };
        }


        public double GetMetabolism(int age, int gender, double height, double weight)
        {
            KeyValuePair<string, string>[] parameters = new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("age", age.ToString()),
                new KeyValuePair<string, string>("gender", gender.ToString()),
                new KeyValuePair<string, string>("height", height.ToString("F0")),
                new KeyValuePair<string, string>("weight", weight.ToString("F0"))
            };

            MetabolismResponse response = GetResponse<MetabolismResponse>("metabolism", parameters);

            return response.Result;
        }

        public double GetIdealWeight(int age, double height, int bodyType)
        {

            KeyValuePair<string, string>[] parameters = new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("bodytype", bodyType.ToString()),
                new KeyValuePair<string, string>("height", height.ToString("F0")),
                new KeyValuePair<string, string>("age", age.ToString())
            };

            WeightResponse response = GetResponse<WeightResponse>("weight", parameters);

            return response.Result;
        }

        public int GetBodyType(int gender, double handDiameter)
        {
            KeyValuePair<string, string>[] parameters = new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("gender", gender.ToString()),
                new KeyValuePair<string, string>("handdiameter", handDiameter.ToString("F0"))
            };

            BodyTypeResponse response = GetResponse<BodyTypeResponse>("bodytype", parameters);

            return response.BodyType;
        }
    }
}
