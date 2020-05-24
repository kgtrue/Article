using Articles.Core.Application.Common.Exceptions;
using Articles.Core.Application.Common.Interfaces.Contracts;
using Articles.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Articles.Core.Application.Authors.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand : IRequest
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public class Handler : IRequestHandler<UpdateAuthorCommand>
        {
            private readonly IAuthorRepo _authorRepo;
            private readonly IMediator _mediator;
            public Handler(
                IAuthorRepo authorRepo,
                IMediator mediator)
            {
                _authorRepo = authorRepo;
                _mediator = mediator;
            }
            public async Task<Unit> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
            {
                var author = await _authorRepo.GetById(request.Id, cancellationToken);
                if (author == null)
                {
                    throw new NotFoundException(nameof(Author), request.Id);
                }
                author.FirstName = request.FirstName;
                author.LastName = request.LastName;
                await _authorRepo.Update(author, cancellationToken);
                return Unit.Value;
            }
        }
    }
}
