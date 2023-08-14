using Microsoft.AspNetCore.Mvc;
using Repository_pattern.Model;
using Repository_pattern.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Repository_pattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userController : ControllerBase
    {
        private readonly IRepository<user> repomethods;
        public userController(IRepository<user> repository) {
            repomethods = repository;
        }
        // GET: api/<userController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users =await repomethods.GetAllasync();
            return users != null ? Ok(users) : NoContent();
        }

        // GET api/<userController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = repomethods.Find(id);
            return user != null ? Ok(user) : NoContent();

        }

        // POST api/<userController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]user value)
        {
            var k=await repomethods.Addasync(value);
            return k==true ? Ok("Inserted successfully") : NoContent();
        }

        // PUT api/<userController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]user value)
        {
            var user = repomethods.Find(id);
            if (user != null)
            {
                var K=await repomethods.DeleteAsync(user);
                var k = await repomethods.Addasync(value);
                return k == true ? Ok("Updated Successfully") : NoContent();
            }
            return NoContent(); 
        }


        // DELETE api/<userController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user =repomethods.Find(id);
            var k=await repomethods.DeleteAsync(user);
            return k == true ? Ok("Deleted successfully") : NoContent();

        }
    }
}
