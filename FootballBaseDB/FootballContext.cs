using FootballBaseDB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FootballBaseDB
{
    public class FootballContext : DbContext
    {
        public FootballContext() : base("FootballBaseDB")
        { }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}