using Microsoft.AspNetCore.Mvc;
using MinimalAPI.Models;
using System.Drawing;

namespace MinimalAPI.Controllers
{
    [ApiController]                                 //this is called a C# attribute to decorate this class
    [Route("api/[controller]")]               
    public class ShirtsController: ControllerBase   //in order to make this class a WebAPI controller we need to derive from ControllerBase
    {                                               //Controllers are just classes used to organize the endpoints.
        [HttpGet]
        public string GetShirts()
        {
            return "Reading all the shirts";
        }

        //What is Data Binding : To map data from an HTTP request to parameters in your action methods. 

        [HttpGet("{id}")]
        //public string GetShirtsById(int id, [FromHeader(Name = "Color")] string color)       //[FromRoute], [FromHeader], [FromQuery], [FromBody], [FromForm]
        public string GetShirtsById(int id)
        {
            return $"Reading shirt: {id}";
        }

        [HttpPost]
        public string CreateShirt([FromForm]Shirt shirt)
        {
            return "Creating a shirt";
        }

        [HttpPut("{id}")]
        public string UpdateShirt(int id)
        {
            return $"Updating shirt: {id}";
        }

        [HttpDelete("{id}")]
        public string DeleteShirt(int id)
        {
            return $"Deleting shirt: {id}";
        }
    }
}
