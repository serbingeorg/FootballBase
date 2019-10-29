using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace FootballBaseDB.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public string CountryName { get; set; }


        public  ICollection<Player> Players { get; set; }
        public Team()
        {
            Players = new List<Player>();
        }

  
     

    }
}