﻿using FootballBaseDB.Models;
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
        FootballContext bd = new FootballContext();

        [HttpGet]
        [Route ("api/players/")]
        public IEnumerable <Player> GetPlayers()
        {
            return bd.Players;
        }

        [HttpGet]
        [Route ("api/{id}/player")]
        public Player GetPlayer (int id)
        {
            Player player = bd.Players.Find(id);
            return player;
        }
        [HttpPost]
        [Route("api/players/")]
        public void CreatePlayer([FromBody] Player player)
        {
            bd.Players.Add(player);
            bd.SaveChanges();
        }

        [HttpPut]
        public void EditPlayer(int id, [FromBody] Player player)
        {
            if (id == player.Id)
            {
                bd.Entry(player).State = EntityState.Modified;
                bd.SaveChanges();
            }
        }

        [HttpDelete]
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
