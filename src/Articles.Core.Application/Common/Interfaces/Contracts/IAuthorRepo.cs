using Articles.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Articles.Core.Application.Common.Interfaces.Contracts
{
    public interface IAuthorRepo
    {
        public Task<Author> GetById(Guid id, CancellationToken cancellationToken);
        public Task<Author> Save(Author author, CancellationToken cancellationToken);
        public Task Update(Author author, CancellationToken cancellationToken);
    }
}
