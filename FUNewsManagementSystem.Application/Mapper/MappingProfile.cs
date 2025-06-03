using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FUNewsManagementSystem.Core.Entities;
using FUNewsManagementSystem.Core.DTOs;

namespace FUNewsManagementSystem.Core.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<NewsArticle, NewsArticleDTO>().ReverseMap();
            CreateMap<SystemAccount, SystemAccountDTO>().ReverseMap();
            CreateMap<Tag, TagDTO>().ReverseMap();
        }
    }

}
