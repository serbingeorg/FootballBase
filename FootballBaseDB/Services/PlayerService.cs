using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using FootballBaseDB.Models;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Net.Http;
using System.Threading.Tasks;
using FootballBaseDB.ViewModels;
using AutoMapper;
using FootballBaseDB.Infastructure.Mappings;

namespace FootballBaseDB.Services
{
    public class PlayerService
    {
        FootballContext bd = new FootballContext();
        public async Task <IEnumerable<Player>> GetAllPlayers()
        {
            var res = await  bd.Players.Include(p => p.Team).ToListAsync();
            return res;
        }

        public PlayerViewModel Test ()
        {
            Player player = bd.Players.FirstOrDefault(p => p.Id == 1);
            IMapper mapper = new AutoMapperWebConfiguration().Configuration.CreateMapper();
            PlayerViewModel playerView = mapper.Map<Player, PlayerViewModel>(player);
            return playerView;

        }
        public async Task  <Player> GetPlayerOne(int id)
        {
            Player player = await  bd.Players.Where (i =>i.Id==id).Include(t=>t.Team).FirstOrDefaultAsync();
            return player;
        }

        public async Task AddPlayer( Player player)
        {
            bd.Players.Add(player);
           await  bd.SaveChangesAsync();
            
        }
        public async Task EditPlayer(int id,  Player player)
        {
            if (id == player.Id)
            {
                bd.Entry(player).State = EntityState.Modified;
               await bd.SaveChangesAsync();
            }
        }
        public async Task DeletePlayer(int id)
        {
            Player player = bd.Players.Find(id);
            if (player != null)
            {
                bd.Players.Remove(player);
               await bd.SaveChangesAsync();

            }
        }
    }
}