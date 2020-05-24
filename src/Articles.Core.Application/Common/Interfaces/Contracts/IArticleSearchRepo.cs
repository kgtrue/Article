using Articles.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Articles.Core.Application.Common.Interfaces.Contracts
{
    public interface IArticleSearchRepo
    {
        public Task<IEnumerable<Article>> Search(Expression<Func<Article, bool>> filter, CancellationToken cancellationToken);
    }
}
