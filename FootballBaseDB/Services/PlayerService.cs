using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using FootballBaseDB.Models;


namespace FootballBaseDB.Services
{
    public class PlayerService
    {
        FootballContext bd = new FootballContext();
        public IEnumerable<Player> GetAllPlayers()
        {
            var res = bd.Players.Include(p => p.Team).ToList();
            return res;
        }

    }
}