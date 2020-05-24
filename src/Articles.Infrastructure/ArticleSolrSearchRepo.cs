using Articles.Core.Application.Common.Interfaces.Contracts;
using Articles.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Articles.Infrastructure
{
    public class ArticleSolrSearchRepo : IArticleSearchRepo
    {
        public Task<IEnumerable<Article>> Search(Expression<Func<Article, bool>> predicate, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
