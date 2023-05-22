using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChandigarhAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        ChandigarhEstatesContext db = new ChandigarhEstatesContext();
        public Login AutheticateUser(Login login)
        {
            Login result = db.Logins.Where(p => p.Email == login.Email 
                && p.Password == login.Password && p.IsActive == login.IsActive).FirstOrDefault();

            return result;
        }

    }
}
