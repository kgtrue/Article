using System;
using System.Collections.Generic;
using System.Text;

namespace Articles.Persistence
{
    public abstract class BaseRepo
    {
        protected readonly ArticleDbContext _articleDbContext;
        public BaseRepo(ArticleDbContext articleDbContext)
        {
            _articleDbContext = articleDbContext;
        }
    }
}
