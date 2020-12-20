using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Logging;

using HealthCloud.Web.Models;
using HealthCloud.Web.Models.Database;

namespace HealthCloud.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private ApplicationContext _context;
        private ILogger<ProductsController> _logger;

        public ProductsController(ApplicationContext context, ILogger<ProductsController> logger) 
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("list")]
        public IActionResult GetProducts()
        {
            IList<Product> products = _context.Products.ToList();

            return Ok(products);
        }

        [HttpGet("select")]
        public IActionResult SelectProducts([FromQuery] int start,  [FromQuery]int count)
        {
            IList<Product> result = _context.Products.Skip(start).Take(count).ToList();

            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult AddProduct([FromQuery]string password, [FromBody] AddProductData data)
        {
            if(password != "12345678")
            {
                return BadRequest("You cannot do this");
            }

            Product product = _context.Products.FirstOrDefault(p => p.Name == data.Name);

            if(product != null)
            {
                return BadRequest("Product already exists");
            }

            int newId = _context.Products.OrderByDescending(p => p.Id).First().Id + 1;

            product = new Product()
            {
                Id = newId,
                Name = data.Name,
                Fats = data.Fats,
                Proteins = data.Proteins,
                Carbons = data.Carbons,
                Calories = data.Calories
            };

            _logger.LogInformation($"New Product added: {newId}.{data.Name}");

            _context.Add(product);

            _context.SaveChanges();

            return Ok();
        }

        [HttpPost("remove")]
        public IActionResult RemoveProduct([FromQuery]string password, [FromQuery] string name)
        {
            if (password != "12345678")
            {
                return BadRequest("You cannot do this");
            }

            Product product = _context.Products.FirstOrDefault(p => p.Name == name);

            if (product == null)
            {
                return BadRequest("Product does not exists");
            }

            _context.Remove(product);

            _logger.LogInformation($"Product removed: {name}");

            _context.SaveChanges();

            return Ok();
        }
    }
}