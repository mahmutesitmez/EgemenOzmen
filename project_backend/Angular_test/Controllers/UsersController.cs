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
        public IActionResult Register(RegisterModel register)
        {
         
            return Ok(UserCRUD.Register(register));
        }
        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] LoginModel login)
        {
            var loginReturnModel = UserCRUD.Login(login.Email,login.Password);  
            return Ok(loginReturnModel);    
        }

    }
}
