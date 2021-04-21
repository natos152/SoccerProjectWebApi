using SoccerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SoccerProject.Controllers
{
    [RoutePrefix("api/players")]
    public class PlayersRWController : ApiController
    {
        private static DBSoccerProject DB = new DBSoccerProject();

        //Get All
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(DB.GetPlayers());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
