using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballBaseDB.Infastructure.Mappings
{
    public  class AutoMapperWebConfiguration
    {
        public MapperConfiguration Configuration { get; set; }

        public AutoMapperWebConfiguration()
        {
            Configuration = new MapperConfiguration(c => { c.AddProfile<PlayerViewModelMappingProfile>(); });
        }
    }
}