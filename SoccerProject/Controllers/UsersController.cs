using SoccerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SoccerProject.Controllers
{
    public class UsersController : ApiController
    {
        public List<User> Get()
        {
            DBSoccerProject DB = new DBSoccerProject();
            return DB.GetUsers();
        }
        [HttpGet]
        [Route("api/user/{id}")]
        public User GetUser(int id)
        {
            DBSoccerProject DB = new DBSoccerProject();
            return DB.GetUser(id);
        }
    }
}
