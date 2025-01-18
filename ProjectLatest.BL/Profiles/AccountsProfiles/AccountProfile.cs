using AutoMapper;
using ProjectLatest.BL.DTOs.AccountsDtos;
using ProjectLatest.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLatest.BL.Profiles.AccountsProfiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<AppUser, CreateDto>().ReverseMap();

        }
    }
}
