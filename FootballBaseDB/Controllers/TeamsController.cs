using FootballBaseDB.Models;
using FootballBaseDB.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FootballBaseDB.Controllers
{
    [RoutePrefix ("api/teams")]
    public class TeamsController : ApiController
    {
       // FootballContext db = new FootballContext();
        TeamService teamservice = new TeamService();

        [HttpGet]
        [Route ("all")]
        public async Task <IEnumerable<Team>> GetTeams()
        {
          return await  teamservice.GetAllTeams();
        }

        [HttpGet]
        [Route ("{id}")]
        public async Task <Team > GetTeam(int id)
        {
            return await teamservice.GetTeamOne(id);
        }

        [HttpPost]
        [Route("add")]
        public async Task <IHttpActionResult> CreateTeam([FromBody] Team team)
        {
            try
            {
               await teamservice.AddTeam(team);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut]
        [Route("put/{id}")]
        public async Task <IHttpActionResult> EditTeam (int id,  Team team)
        {
            try
            {
               await teamservice.EditTeam(id, team);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task <IHttpActionResult> DeleteTeam (int id)
        {
            try
            {
               await teamservice.DeleteTeam(id);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok();

        }

    }
}
