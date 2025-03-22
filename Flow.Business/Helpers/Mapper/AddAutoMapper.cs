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
using Microsoft.Extensions.DependencyInjection;
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
            CreateMap<SocialMedia,GetSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, CreateSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, UpdateSocialMediaDto>().ReverseMap();

            CreateMap<Blog, GetBlogDto>().ReverseMap();
            CreateMap<Blog, CreateBlogDto>().ReverseMap();
            CreateMap<Blog, UpdateBlogDto>().ReverseMap();

            CreateMap<Tag, GetTagDto>().ReverseMap();
            CreateMap<Tag, CreateTagDto>().ReverseMap();
            CreateMap<Tag, UpdateTagDto>().ReverseMap();

            CreateMap<Color, GetColorDto>().ReverseMap();
            CreateMap<Color, CreateColorDto>().ReverseMap();

            CreateMap<BlogTag, GetBlogTagDto>().ReverseMap();
            CreateMap<BlogTag, CreateBlogTagDto>().ReverseMap();

            CreateMap<Category, GetCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();

            CreateMap<ContactFormDto, string>().ReverseMap();

            CreateMap<CreateFileUploadDto, string>().ReverseMap();
            CreateMap<GetFileUploadDto, string>().ReverseMap();
        }
    }
}
