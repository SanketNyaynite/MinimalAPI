using Microsoft.AspNetCore.Mvc;
using MinimalAPI.Models;
using MinimalAPI.Models.Repositories;
using System.Drawing;

namespace MinimalAPI.Controllers
{
    [ApiController]                                 //this is called a C# attribute to decorate this class
    [Route("api/[controller]")]               
    public class ShirtsController: ControllerBase   //in order to make this class a WebAPI controller we need to derive from ControllerBase
    {                                               //Controllers are just classes used to organize the endpoints.
        //below is called in-memory list/repository to simulate a database.
        //private List<Shirt> shirts = new List<Shirt>()
        //{
        //    new Shirt { ShirtId = 1, Brand ="Goof", Color="Blue", Gender= "Men", Price = 30, Size = 10 },
        //    new Shirt { ShirtId = 2, Brand ="Swoof", Color="Black", Gender= "Men", Price = 35, Size = 12 },
        //    new Shirt { ShirtId = 3, Brand ="Loof", Color="Green", Gender= "Women", Price = 28, Size = 8 },
        //    new Shirt { ShirtId = 4, Brand ="Doof", Color="Red", Gender= "Women", Price = 30, Size = 9 },

        //};
        
        [HttpGet]
        public IActionResult GetShirts()
        {
            return Ok("Reading all the shirts");
        }

        //What is Data Binding : To map data from an HTTP request to parameters in your action methods. 

        //public string GetShirtsById(int id, [FromHeader(Name = "Color")] string color)       //[FromRoute],[FromHeader],[FromQuery], [FromBody], [FromForm]

        [HttpGet("{id}")]
        public IActionResult GetShirtsById(int id)                 //use IActionResult when you want to return different types of responses.
        {
            if(id<=0)
            {
                return BadRequest("Invalid shirt ID");          //400 Bad Request
            }

            //var shirt = shirts.FirstOrDefault(x => x.ShirtId == id);
            var shirt = ShirtRepository.GetShirtById(id);
            if (shirt == null)
            {
                return NotFound();
            }
            return Ok(shirt);
        }

        [HttpPost]
        public IActionResult CreateShirt([FromBody]Shirt shirt)
        {
            return Ok("Creating a shirt");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateShirt(int id)
        {
            return Ok($"Updating shirt: {id}");
        }

        [HttpDelete("{id}")]
        public string DeleteShirt(int id)
        {
            return $"Deleting shirt: {id}";
        }
    }
}
