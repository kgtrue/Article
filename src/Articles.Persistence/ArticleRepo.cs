using Articles.Core.Application.Common.Interfaces.Contracts;
using Articles.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Articles.Persistence
{
    public class ArticleRepo : BaseRepo, IArticleRepo
    {
        public ArticleRepo(ArticleDbContext articleDbContext) : base(articleDbContext) { }
        public async Task Delete(Guid articleId, CancellationToken cancellationToken)
        {
            var entry = await _articleDbContext.Articles.FindAsync(articleId, cancellationToken);
            _articleDbContext.Articles.Remove(entry);
            await _articleDbContext.SaveChangesAsync(cancellationToken);
        }
        public async Task<IEnumerable<Article>> GetAll(CancellationToken cancellationToken)
        {
            var results = await _articleDbContext.Articles.Include(e=>e.Author).ToListAsync(cancellationToken);
            return results;
        }
        public async Task<Article> GetById(Guid id, CancellationToken cancellationToken)
        {
            return await _articleDbContext.Articles.Include(e=>e.Author).SingleOrDefaultAsync(e => e.Id == id, cancellationToken);
        }
        public async Task<Article> Save(Article article, CancellationToken cancellationToken)
        {
            var entry = await _articleDbContext.Articles.AddAsync(article, cancellationToken);
            await _articleDbContext.SaveChangesAsync(cancellationToken);
            return entry.Entity;
        }
        public async Task Update(Article article, CancellationToken cancellationToken)
        {
            var entry = _articleDbContext.Set<Article>().Update(article);
            await _articleDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
