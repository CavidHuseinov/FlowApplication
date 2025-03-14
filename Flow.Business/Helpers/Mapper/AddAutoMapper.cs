using AutoMapper;
using Flow.Business.Helpers.DTOs.SocialMedia;
using Flow.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow.Business.Helpers.Mapper
{
    public class AddAutoMapper : Profile
    {
        public AddAutoMapper()
        {
            CreateMap<SocialMedia, GetSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, UpdateSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, CreateSocialMediaDto>().ReverseMap();

        }
    }
}
