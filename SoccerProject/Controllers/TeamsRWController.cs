using SoccerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace SoccerProject.Controllers
{
    //[RoutePrefix("api/teams")]
    public class TeamsRWController : ApiController
    {
         private static DBSoccerProject DB = new DBSoccerProject();

        //Get All
        
        public IHttpActionResult Get()
        {
            try
            {
                List<Team> teams = DB.GetTeams();
                return Ok(DB.GetTeams());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        //Get One Team
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                Team t = DB.GetTeams().FirstOrDefault(te => te.IdTeam == id);
                if (t.Equals(null))
                {
                    return Content(HttpStatusCode.NotFound, "Team with id=" + id + " was not found!");
                }
                return Ok(t);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/teamsRW/post")]
        public IHttpActionResult Post([FromBody] Team team)
        {
            try
            {
                return Created(new Uri(Request.RequestUri.AbsoluteUri + team.IdTeam), DB.Post(team));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult Put(int id, [FromBody] Team team)
        {
            try
            {
                int res = DB.Put(id, team);
                DB.Put(id, team);
                return Ok(res);
            }
            catch (Exception)
            {
                //BadRequest(ex.Message);
                return Content(HttpStatusCode.NotFound, $"Team with id={id} was not found to update!");
            }

        }
        [HttpDelete, Route("api/del/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                    int res = DB.Delete(id);
                    return Ok("Success");
            }
            catch (Exception)
            {
                return Content(HttpStatusCode.NotFound, $"Team with id={id} was not found to Delete!");
            }
        }
    }    
}

