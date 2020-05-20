using Microsoft.AspNetCore.Mvc;
using WebServer.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace WebServer.Controllers
{
    [Route("api/[controller]")]
    public class PeopleController : Controller
    {
        // Get all people
        [HttpGet]
        public Person[] GetPeople()
        {
            return Repository.People.ToArray();
        }
        
        // Get person by ID
        [HttpGet("{id}")]
        public Person GetPerson(int id)
        {
            return Repository.GetPersonByID(id);
        }

        // Create a new person
        [HttpPost]
        public ActionResult Post([FromBody] Person person)
        {
            if (person == null) {
                if (! ModelState.IsValid) {
                    return BadRequest(ModelState.Values.First().Errors.First().ErrorMessage);
                } else {
                    return BadRequest("Person object is NULL");
                }
            }

            Repository.AddPerson(person);
            return Ok();
        }

        // Replace existing person
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Person person)
        {
            Repository.ReplacePersonByID(id, person);
        }

        // Delete existing person
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Repository.RemovePersonByID(id);
        }
    }
}