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

        public IEnumerable<Team> GetTeams()
        {
            return db.Teams;
        }

        public Team GetTeam(int id)
        {
            Team team = db.Teams.Find(id);
            return team;
        }

        [HttpPost]
        public void CreateTeam([FromBody] Team team)
        {
            db.Teams.Add(team);
            db.SaveChanges();
        }

        [HttpPut]
        public void EditTeam (int id, [FromBody] Team team)
        {
            if (id == team.Id)
            {
                db.Entry(team).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

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
