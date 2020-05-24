using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Articles.Core.Application.Common.Interfaces
{
    public interface IArticleDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
