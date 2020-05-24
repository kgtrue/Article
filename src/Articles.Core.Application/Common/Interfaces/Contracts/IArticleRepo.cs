using Articles.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Articles.Core.Application.Common.Interfaces.Contracts
{
    public interface IArticleRepo: IArticleSearchRepo
    {
        public Task<Article> GetById(Guid id, CancellationToken cancellationToken);
        public Task<IEnumerable<Article>> GetAll(CancellationToken cancellationToken);
        public Task<Article> Save(Article article, CancellationToken cancellationToken);
        public Task Delete(Guid articleId, CancellationToken cancellationToken);
        public Task Update(Article article, CancellationToken cancellationToken);
    }
}
