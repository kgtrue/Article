using System;
using System.Collections.Generic;
using System.Text;

namespace Articles.Core.Application.Articles.Queries.GetArticleList
{
   public class GetArticleListVM
    {
        public IEnumerable<ArticleLookupDto> Articles { get; set; }
    }
}
