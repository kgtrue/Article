using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Articles.Core.Application.Articles.Queries.GetArticleList
{
    public class GetArticlesListQuery : IRequest<GetArticleListVM>
    {
    }
}
