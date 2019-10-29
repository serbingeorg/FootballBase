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
    [Route ("api/teams")]
    public class TeamsController : ApiController
    {
        FootballContext db = new FootballContext();

        [HttpGet]
        [Route ("teams")]
        public IEnumerable<Team> GetTeams()
        {
            var res = db.Teams.Include(t=>t.Players).ToList();
            return res;
        }

        [HttpGet]
        [Route ("teams/{id}")]
        public Team GetTeam(int id)
        {
            Team team = db.Teams.Find(id);
            return team;
        }

        [HttpPost]
        [Route("teams")]
        public void CreateTeam([FromBody] Team team)
        {
            db.Teams.Add(team);
            db.SaveChanges();
        }

        [HttpPut]
        [Route("teams/{id}")]
        public void EditTeam (int id, [FromBody] Team team)
        {
            if (id == team.Id)
            {
                db.Entry(team).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        [HttpDelete]
        [Route("teams/{id}")]
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
