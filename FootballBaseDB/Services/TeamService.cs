using FootballBaseDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace FootballBaseDB.Services
{
    public class TeamService
    {
        FootballContext db = new FootballContext();
        public IEnumerable<Team>GetAllTeams()
        {
            var res = db.Teams.Include(t => t.Players).ToList();
            return res;
        }
    }
}