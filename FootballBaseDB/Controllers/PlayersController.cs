using FootballBaseDB.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FootballBaseDB.Controllers
{
    public class PlayersController : ApiController
    {
        FootballContext db = new FootballContext();

        public IEnumerable <Player> GetPlayers()
        {
            return db.Players;
        }

        public Player GetPlayer (int id)
        {
            Player player = db.Players.Find(id);
            return player;
        }


      
    }
}
