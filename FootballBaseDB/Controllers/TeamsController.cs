using FootballBaseDB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FootballBaseDB.Controllers
{
    public class TeamsController : ApiController
    {
        FootballContext db = new FootballContext();

        [HttpGet]
        [Route ("api/teams/")]
        public IEnumerable<Team> GetTeams()
        {
            return db.Teams;
        }

        [HttpGet]
        [Route ("api/{id}/team")]
        public Team GetTeam(int id)
        {
            Team team = db.Teams.Find(id);
            return team;
        }

        [HttpPost]
        [Route("api/teams/")]
        public void CreateTeam([FromBody] Team team)
        {
            db.Teams.Add(team);
            db.SaveChanges();
        }

        [HttpPut]
        [Route("api/{id}/team")]
        public void EditTeam (int id, [FromBody] Team team)
        {
            if (id == team.Id)
            {
                db.Entry(team).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        [HttpDelete]
        [Route("api/{id}/team")]
        public void DeleteTeam (int id)
        {
            Team team = db.Teams.Find(id);
            if (team != null)
            {
                db.Teams.Remove(team);
                db.SaveChanges();

            }
        }

    }
}
