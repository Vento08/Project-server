using System;
using Microsoft.AspNetCore.Mvc;

using HealthCloud.Web.Models.Calculations;
using HealthCloud.Web.Models.Database;

namespace HealthCloud.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CalculationsController : Controller
    {
        private ApplicationContext _context;

        public CalculationsController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet("calories")]
        public IActionResult GetDailyCalories([FromQuery] CaloriesData data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            double temp = 10 * data.Weight + 6.25f * data.Height - 5 * data.Age;

            if (data.Gender == 0)
            {
                temp += 5;
            }
            else
            {
                temp -= 161;
            }

            temp = temp * data.GetMultiplier();

            var result = new
            {
                Result = Math.Round(temp, 2),
                Loss = Math.Round(temp * 0.75f, 2)
            };

            return Json(result);
        }

        [HttpGet("metabolism")]
        public IActionResult GetMetabolism([FromQuery] MetabolismData data)
        {
            double result;
            if(data.Gender == 0)
            {
                result = 88.362 + 13.397 * data.Weight + 4.799 * data.Height - 5.677 * data.Age;
            }
            else
            {
                result = 447.599 + 9.247 * data.Weight + 3.098 * data.Height - 4.330 * data.Age;
            }


            return Json(new { Result = Math.Round(result, 2) }); ;
        }

        [HttpGet("weight")]
        public IActionResult GetIdealWeight([FromQuery] IdealWeightData data)
        {
            double result = data.Height - (data.Age <= 40 ? 110 : 100);

            result *= data.GetBodyTypeMultiplier();

            return Json(new { Result = Math.Round(result, 2) });
        }

        [HttpGet("bmi")]
        public IActionResult GetMassIndex([FromQuery] BodyMassIndexData data)
        {
            double result = (data.Weight * data.GetBodyTypeMultiplier()) / Math.Pow(data.Height, 2);

            int condition;
            if(result < 18.5)
            {
                condition = 0;
            }
            else if(result < 25)
            {
                condition = 1;
            }
            else if(result <= 30)
            {
                condition = 2;
            }
            else
            {
                condition = 3;
            }

            var resulObject = new
            {
                Result = Math.Round(result, 2),
                Condition = condition
            };

            return Json(resulObject);
        }

        [HttpGet("bodytype")]
        public IActionResult GetBodyType([FromQuery] int gender, [FromQuery] double handDiameter)
        {
            int type;

            int firstCheck = gender == 0 ? 18 : 15;
            int secondCheck = gender == 0 ? 20 : 17;

            if(handDiameter < firstCheck)
            {
                type = 0;
            }
            else if(handDiameter < secondCheck)
            {
                type = 1;
            }
            else
            {
                type = 2;
            }

            return Json(new { BodyType = type });
        }

    }
}