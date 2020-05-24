using Articles.Core.Application.Common.Mappings;
using Articles.Core.Entities;
using AutoMapper;
using System;

namespace Articles.Core.Application.Articles.Queries.GetArticleList
{
    public class ArticleLookupDto : IMapFrom<Article>
    {
        public Guid Id { get; set; }
        public string Heading { get; set; }
        public string Text { get; set; }
        public uint Year { get; set; }
        public AuthorDto Author { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Article, ArticleLookupDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Heading, opt => opt.MapFrom(s => s.Heading))
                .ForMember(d => d.Text, opt => opt.MapFrom(s => s.Text))
                .ForMember(d => d.Year, opt => opt.MapFrom(s => s.Year))
                .ForMember(d => d.Author, opt => opt.MapFrom(s => s.Author));
        }
    }
}
