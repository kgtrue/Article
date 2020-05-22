using Articles.Core.Application.Common.Interfaces.Contracts;
using Articles.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Articles.Core.Application.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommand : IRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public class Handler : IRequestHandler<CreateAuthorCommand>
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
            public async Task<Unit> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
            {
                var entity = new Author()
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                };
                var result = await _authorRepo.Save(entity, cancellationToken);
                return Unit.Value;
            }
        }
    }
}
