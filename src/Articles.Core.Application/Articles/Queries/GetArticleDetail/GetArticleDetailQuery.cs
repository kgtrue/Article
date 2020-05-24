using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Articles.Core.Application.Articles.Queries.GetArticleDetail
{
    public class GetArticleDetailQuery : IRequest<ArticleDetailVM>
    {
        public Guid ArticleId { get; set; }
    }
}
