using AutoMapper;
using Flow.Business.Helpers.DTOs.Blog;
using Flow.Business.Helpers.DTOs.BlogTag;
using Flow.Business.Helpers.DTOs.Category;
using Flow.Business.Helpers.DTOs.Color;
using Flow.Business.Helpers.DTOs.Contact;
using Flow.Business.Helpers.DTOs.FileUpload;
using Flow.Business.Helpers.DTOs.SocialMedia;
using Flow.Business.Helpers.DTOs.Tag;
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

            CreateMap<GetFileUploadDto, string>().ReverseMap();
            CreateMap<string, CreateFileUploadDto>().ReverseMap();

            CreateMap<ContactFormDto,string>().ReverseMap();

            CreateMap<GetBlogDto, Blog>().ReverseMap();
            CreateMap<CreateBlogDto, Blog>().ReverseMap();
            CreateMap<UpdateBlogDto, Blog>().ReverseMap();

            CreateMap<GetCategoryDto, Category>().ReverseMap();
            CreateMap<CreateCategoryDto, Category>().ReverseMap();
            CreateMap<UpdateCategoryDto, Category>().ReverseMap();

            CreateMap<BlogTag, GetBlogTagDto>().ReverseMap();
            CreateMap<BlogTag, CreateBlogTagDto>().ReverseMap();

            CreateMap<Tag,GetTagDto>().ReverseMap();
            CreateMap<Tag, CreateTagDto>().ReverseMap();
            CreateMap<Tag, UpdateTagDto>().ReverseMap();

            CreateMap<Color, GetColorDto>().ReverseMap();
            CreateMap<Color, CreateColorDto>().ReverseMap();
        }
    }
}
