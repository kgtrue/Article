using Articles.Core.Application.Common.Exceptions;
using Articles.Core.Application.Common.Interfaces.Contracts;
using Articles.Core.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Articles.Core.Application.Articles.Queries.GetArticleDetail
{
    public class GetArticleDetailQueryHandler : IRequestHandler<GetArticleDetailQuery, ArticleDetailVM>
    {
        private readonly IArticleRepo _articleRepo;
        private readonly IMapper _mapper;
        public GetArticleDetailQueryHandler(
            IArticleRepo articleRepo,
            IMapper mapper)
        {
            _articleRepo = articleRepo;
            _mapper = mapper;
        }
        public async Task<ArticleDetailVM> Handle(GetArticleDetailQuery request, CancellationToken cancellationToken)
        {
            var article = await _articleRepo.GetById(request.ArticleId, cancellationToken);
            if (article == null)
            {
                throw new NotFoundException(nameof(Article), request.ArticleId);
            }
            return _mapper.Map<Article, ArticleDetailVM>(article);
        }
    }
}
