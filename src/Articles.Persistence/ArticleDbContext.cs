using Articles.Core.Application.Common.Interfaces;
using Articles.Core.Common;
using Articles.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Articles.Persistence
{
    public class ArticleDbContext : DbContext, IArticleDbContext
    {
        ArticleDbContext()
        {

        }

        public ArticleDbContext(DbContextOptions<ArticleDbContext> options)
        : base(options)
        {
        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Author> Authors { get; set; }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            try
            {
                foreach (var entry in ChangeTracker.Entries<IEntity>())
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entry.Entity.CreatedDate = DateTime.Now;
                            break;
                        case EntityState.Modified:
                            entry.Entity.UpdateDate = DateTime.Now;
                            break;
                    }
                }
                return base.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ArticleDbContext).Assembly);
        }
    }
}
