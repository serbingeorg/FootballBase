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

        public PlayerViewModelMappingProfile()
        {
             CreateMap<Player, PlayerViewModel>()
            .ForMember(dest => dest.PlayerName, opt => opt.MapFrom(src => FormatPlayerName(src.FirstName, src.LastName)));

        }
       

        private string FormatPlayerName (string first, string last)
        {
            string res = first + " " + last;
            res = res + " " + res.Length;
            return res;
        }

    }
}