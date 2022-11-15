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


        [HttpPost]
        [Route("Register")]
        public IActionResult Register([FromBody] RegisterModel register)
        {
            //[FromBody] olmadan client'ta nasıl yazılır??
            return Ok(UserCRUD.Register(register));
        }
        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] LoginModel login)
        {
            var loginReturnModel = UserCRUD.Login(login.Email, login.Password);
            return Ok(loginReturnModel);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            UserCRUD.Delete(id);
            return Ok();
        }
        [HttpPut("{password}/{email}")]
        [ValidateModel]
        //[MyException]
        public IActionResult Put(string password,string email, [FromBody] RegisterModel register)
        {
            var cat = UserCRUD.GetByPassword(password);
            var catemail = UserCRUD.GetByEmail(email);
            if (cat != null &catemail != null)
            {
                cat = UserCRUD.Update(register);
            }
            else
            {
                return BadRequest("Geçersiz id");
            }
            return Ok(cat);
        }


    }
}