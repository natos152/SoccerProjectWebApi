using SoccerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SoccerProject.Controllers
{
    //[RoutePrefix("api/playersRW")]
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

        [HttpPost]
        [Route("api/playersRW/post")]
        public IHttpActionResult Post([FromBody] Player player)
        {
            try
            {
                return Created(new Uri(Request.RequestUri.AbsoluteUri + player.PlayerName), DB.PostPlayer(player));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
