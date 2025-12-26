using Microsoft.AspNetCore.Mvc;
using MinimalAPI.Filters;
using MinimalAPI.Filters.ActionFilters;
using MinimalAPI.Filters.ExceptionFilters;
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
            return Ok(ShirtRepository.GetShirts());
        }

        //What is Data Binding : To map data from an HTTP request to parameters in your action methods. 

        //public string GetShirtsById(int id, [FromHeader(Name = "Color")] string color)       //[FromRoute],[FromHeader],[FromQuery], [FromBody], [FromForm]

        [HttpGet("{id}")]
        [Shirt_ValidateShirtIdFilter]       //Model Validation using Action Filter Attribute to validate ShirtId before executing the action method.
        public IActionResult GetShirtsById(int id)                 //use IActionResult when you want to return different types of responses.
        {
            
            return Ok(ShirtRepository.GetShirtById(id));
        }

        [HttpPost]
        [Shirt_ValidateCreateShirtFilter]
        public IActionResult CreateShirt([FromBody]Shirt shirt)
        {
            ShirtRepository.AddShirt(shirt);

            //below is to return 201 Created response with location header pointing to the newly created resource
            return CreatedAtAction(nameof(GetShirtsById), 
                new { id = shirt.ShirtId }, 
                shirt);
        }

        [HttpPut("{id}")]
        [Shirt_ValidateShirtIdFilter]
        [Shirt_ValidateUpdateShirtFilter]
        [Shirt_HandleUpdateExceptionsFilter]                //press ctrl +. to add using statement for the filter
        public IActionResult UpdateShirt(int id, Shirt shirt)
        {            
                ShirtRepository.UpdateShirt(shirt);
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Shirt_ValidateShirtIdFilter]
        public IActionResult DeleteShirt(int id)
        {
            var shirt = ShirtRepository.GetShirtById(id);
            ShirtRepository.DeleteShirt(id);

            return Ok(shirt);
        }
    }
}