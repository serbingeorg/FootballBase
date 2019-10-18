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

        [HttpGet]
        [Route("api/players/")]
        public IEnumerable <Player> GetPlayers()
        {
            return db.Players;
        }

        [HttpGet]
        [Route("api/{id}/player")]
        public Player GetPlayer (int id)
        {
            Player player = db.Players.Find(id);
            return player;
        }
        [HttpPost]
        public void CreatePlayer([FromBody] Player player)
        {
            db.Players.Add(player);
            db.SaveChanges();
        }

        [HttpPut]
        public void EditPlayer(int id, [FromBody] Player player)
        {
            if (id == player.Id)
            {
                db.Entry(player).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        [HttpDelete]
        public void DeletePlayer(int id)
        {
            Player player = db.Players.Find(id);
            if (player != null)
            {
                db.Players.Remove(player);
                db.SaveChanges();

            }
        }



    }
}
