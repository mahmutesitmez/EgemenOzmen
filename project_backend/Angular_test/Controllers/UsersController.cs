using Angular_test.DomainServices;
using Angular_test.Filters;
using Angular_test.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Angular_test.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]

    public class UsersController : ControllerBase
    {
        private readonly IUserCRUD UserCRUD;

        public UsersController(IUserCRUD UserCRUD)
        {
            this.UserCRUD = UserCRUD;
        }


        // GET: api/<UsersController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(UserCRUD.GetAll());
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(UserCRUD.GetById(id));
        }
      
        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            var newuser = UserCRUD.Add(user);
            return Ok(newuser);
        }
        [HttpPost]
        [ValidateModel]
        public IActionResult Login(string email, string password, [FromBody] User user)
        {
            var useremail = user.Email;
            var userpassword = user.Password;
                

        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        [ValidateModel]
        public IActionResult Put(int id, [FromBody] User user)
        {
            var cat = UserCRUD.GetById(id);
            if (cat != null)
            {
                cat = UserCRUD.Update(user);
            }
            else
            {
                return BadRequest("Geçersiz id");
            }
            return Ok(cat);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            UserCRUD.Delete(id);
            return Ok();
        }
    }
}
