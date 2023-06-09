﻿using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace 

{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        ChandigarhEstatesContext db = new ChandigarhEstatesContext();
        public bool AuthenticateUser(Login login)
        {
            Login lg = new Login();
            lg = db.Logins.ToList().Where(p => p.Email == login.Email && p.Password == login.Password && p.IsActive == true).FirstOrDefault();

            if (lg.Email != null )
            {
                return true;
            }
            return false;
        }

        public bool IsAdministrator(Login login)
        {
            Login lg = new Login();
            lg = db.Logins.ToList().Where(p => p.Email == login.Email && p.Password == login.Password && p.IsActive == true).FirstOrDefault();
            if (lg.RoleId == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
