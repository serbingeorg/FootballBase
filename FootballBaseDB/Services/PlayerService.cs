using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using FootballBaseDB.Models;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Net.Http;

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

        public Player GetPlayerOne(int id)
        {
            Player player = bd.Players.Where (i =>i.Id==id).Include(t=>t.Team).FirstOrDefault();
            return player;
        }

        public void AddPlayer( Player player)
        {
            bd.Players.Add(player);
            bd.SaveChanges();
            
        }
        public void EditPlayer(int id,  Player player)
        {
            if (id == player.Id)
            {
                bd.Entry(player).State = EntityState.Modified;
                bd.SaveChanges();
            }
        }
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