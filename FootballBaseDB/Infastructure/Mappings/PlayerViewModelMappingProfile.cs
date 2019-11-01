using AutoMapper;
using FootballBaseDB.Models;
using FootballBaseDB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballBaseDB.Infastructure.Mappings
{
    public class PlayerViewModelMappingProfile : Profile
    {
        public PlayerViewModelMappingProfile ()
        {
            CreateMap<Player, PlayerViewModel>().ForMember(x=>x.PlayerName, x=>x.MapFrom(m=>m.FirstName +' '+m.LastName));
        }
        // читать ссылки по маперу все описано
    }
}