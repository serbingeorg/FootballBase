using FootballBaseDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Http;
using System.Net.Http;
using System.Threading.Tasks;

namespace FootballBaseDB.Services
{
    public class TeamService
    {
        FootballContext db = new FootballContext();
        public async Task <IEnumerable<Team>> GetAllTeams()
        {
            var  res = await db.Teams.Include(t => t.Players).ToListAsync();
            return res;
        }

        public async Task <Team> GetTeamOne(int id)
        {
            Team team = await db.Teams.Where(i => i.Id == id).Include(t => t.Players).FirstOrDefaultAsync();
            return team;
        }

        public async Task AddTeam(Team team)
        {
            db.Teams.Add(team);
           await db.SaveChangesAsync();

        }
        public async Task EditTeam(int id, Team team)
        {
            if (id == team.Id)
            {
                db.Entry(team).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
        }
        public async Task DeleteTeam(int id)
        {
            Team team = db.Teams.Find(id);
            if (team != null)
            {
                db.Teams.Remove(team);
                await db.SaveChangesAsync();

            }
        }
    }
}