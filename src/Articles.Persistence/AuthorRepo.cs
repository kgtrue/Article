using Articles.Core.Application.Common.Interfaces.Contracts;
using Articles.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Articles.Persistence
{
    public class AuthorRepo : BaseRepo, IAuthorRepo
    {
        public AuthorRepo(ArticleDbContext articleDbContext) : base(articleDbContext) { }

        public async Task<IEnumerable<Author>> GetAll(CancellationToken cancellationToken)
        {
            var results = await _articleDbContext.Authors.Include(e => e.Articles).ToListAsync(cancellationToken);
            return results;
        }
        public async Task<Author> GetById(Guid id, CancellationToken cancellationToken)
        {
            return await _articleDbContext.Authors.SingleOrDefaultAsync(e => e.Id == id, cancellationToken);
        }
        public async Task<Author> Save(Author author, CancellationToken cancellationToken)
        {
            var entry = await _articleDbContext.Authors.AddAsync(author, cancellationToken);
            await _articleDbContext.SaveChangesAsync(cancellationToken);
            return entry.Entity;
        }
        public async Task Update(Author author, CancellationToken cancellationToken)
        {
            var entry = _articleDbContext.Authors.Update(author);
            await _articleDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
