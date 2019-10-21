﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballBaseDB.Models
{
    public class Player
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Citizenship { get; set; }

        [ForeignKey("Team")]
        public int? TeamId { get; set; }  
       
        public  Team Team { get; set; }
    }
}