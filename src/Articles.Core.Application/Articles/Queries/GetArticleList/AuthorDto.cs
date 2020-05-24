using Articles.Core.Application.Common.Mappings;
using Articles.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Articles.Core.Application.Articles.Queries.GetArticleList
{
    public class AuthorDto : IMapFrom<Author>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Author, AuthorDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.FirstName, opt => opt.MapFrom(s => s.FirstName))
                .ForMember(d => d.LastName, opt => opt.MapFrom(s => s.LastName));
        }
    }
}
