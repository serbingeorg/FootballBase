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
    [RoutePrefix ("api/players")]
    public class PlayersController : ApiController
    {
        FootballContext bd = new FootballContext();

        [HttpGet]
        [Route ("all")]
        public IEnumerable <Player> GetPlayers()
        {

            var res = bd.Players.Include(p=>p.Team).ToList();
            return res;
            
        }

        [HttpGet]
        [Route ("{id}")]
        public Player GetPlayer (int id)
        {
            Player player = bd.Players.Find(id);
            return player;
        }
        [HttpPost]
        [Route("add")]
        public void CreatePlayer([FromBody] Player player)
        {
            bd.Players.Add(player);
            bd.SaveChanges();
        }

        [HttpPut]
        [Route("put/{id}")]
        public void EditPlayer(int id, [FromBody] Player player)
        {
            if (id == player.Id)
            {
                bd.Entry(player).State = EntityState.Modified;
                bd.SaveChanges();
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public void DeletePlayer(int id)
        {
            Player player = bd.Players.Find(id);
            if (player != null)
            {
                bd.Players.Remove(player);
                bd.SaveChanges();

            }
        }



    }
}
