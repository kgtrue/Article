using Articles.Core.Application.Common.Interfaces.Contracts;
using Articles.Core.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Articles.Core.Application.Articles.Queries.GetArticleList
{
    public class GetArticlesListQueryHandler : IRequestHandler<GetArticlesListQuery, GetArticleListVM>
    {
        private readonly IArticleRepo _articleRepo;
        private readonly IMapper _mapper;
        public GetArticlesListQueryHandler(
            IArticleRepo articleRepo,
            IMapper mapper)
        {
            _articleRepo = articleRepo;
            _mapper = mapper;
        }
        public async Task<GetArticleListVM> Handle(GetArticlesListQuery request, CancellationToken cancellationToken)
        {
            var articles = await _articleRepo.GetAll(cancellationToken);
            var result = new GetArticleListVM()
            {
                Articles = _mapper.Map<IEnumerable<Article>, IEnumerable<ArticleLookupDto>>(articles)
            };
            return result;
        }
    }
}
