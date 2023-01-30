using DBWebApp.DAL;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DBWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        // GET: api/<Animals>
        [HttpGet]
        public IActionResult Get([FromQuery] string? orderBy = "name") 
        {
            try 
            {
                return Ok(Database.GetAll(orderBy));
            }
            catch(ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest("Unhandled error");
            }
        }

        // GET api/<Animals>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Animals>
        [HttpPost]
        public IActionResult Post(Animal animal)
        {
            Database.InsertAnimal(animal);
            return Ok();
        }

        // PUT api/<Animals>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Animal animal)
        {
            Database.UpdateAnimal(id, animal);
            return Ok();
        }

        // DELETE api/<Animals>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Database.DeleteAnimal(id);
        }
    }
}
