using FootballBaseDB.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using FootballBaseDB.Services;
using FootballBaseDB.ViewModels;

namespace FootballBaseDB.Controllers
{
    [RoutePrefix("api/players")]
    public class PlayersController : ApiController
    {
        //FootballContext bd = new FootballContext();
        PlayerService playerservice = new PlayerService();

        [HttpGet]
        [Route("all")]
        public async Task <IEnumerable<Player>> GetPlayers()
        {
            return await playerservice.GetAllPlayers();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task <Player> GetPlayer(int id)
        {
            return await playerservice.GetPlayerOne(id);
        }

        [HttpGet]
        [Route("test")]
        public PlayerViewModel GetPlayerViewModel ()
        {
            return playerservice.Test();
        }

        [HttpGet]
        [Route ("name/{id}")]

        public PlayerViewModel GetPlayerViewModelById(int id)
        {
            return playerservice.GetPlayerViewModelById(id);

        }

        [HttpPost]
        [Route("add")]
        public async Task <IHttpActionResult> CreatePlayer([FromBody] Player player)
        {
            try
            {
              await  playerservice.AddPlayer(player);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut]
        [Route("put/{id}")]
        public async Task <IHttpActionResult> EditPlayer(int id, [FromBody] Player player)
        {
            try
            {
               await playerservice.EditPlayer(id, player);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task <IHttpActionResult> DeletePlayer(int id)
        {
            try
            {
             await   playerservice.DeletePlayer(id);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok();
        }

    }
}
