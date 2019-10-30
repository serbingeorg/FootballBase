using FootballBaseDB.Models;
using FootballBaseDB.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FootballBaseDB.Controllers
{
    [RoutePrefix ("api/teams")]
    public class TeamsController : ApiController
    {
        FootballContext db = new FootballContext();
        TeamService teamservice = new TeamService();

        [HttpGet]
        [Route ("all")]
        public IEnumerable<Team> GetTeams()
        {
            return teamservice.GetAllTeams();
        }

        [HttpGet]
        [Route ("{id}")]
        public Team GetTeam(int id)
        {
            Team team = db.Teams.Where(i=>i.Id==id).Include(t=>t.Players).FirstOrDefault();
            return team;
        }

        [HttpPost]
        [Route("add")]
        public void CreateTeam([FromBody] Team team)
        {
            db.Teams.Add(team);
            db.SaveChanges();
        }

        [HttpPut]
        [Route("put/{id}")]
        public void EditTeam (int id, [FromBody] Team team)
        {
            if (id == team.Id)
            {
                db.Entry(team).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
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
