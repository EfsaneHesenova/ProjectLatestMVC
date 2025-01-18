using AutoMapper;
using ProjectLatest.BL.DTOs.ExploreItemDtos;
using ProjectLatest.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLatest.BL.Profiles.ExploreItemProfiles
{
    public class ExploreItemProfile : Profile
    {
        public ExploreItemProfile()
        {
            CreateMap<ExploreItemPostDto, ExploreItem>().ReverseMap();
            CreateMap<ExploreItemPutDto, ExploreItem>().ReverseMap();   
        }
    }
}
