using Articles.Core.Application.Common.Exceptions;
using Articles.Core.Application.Common.Interfaces.Contracts;
using Articles.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Articles.Core.Application.Articles.Commands.DeleteArticle
{
    public class DeleteArticleCommand : IRequest
    {
        public Guid Id { get; set; }
        public class Handler : IRequestHandler<DeleteArticleCommand>
        {
            private readonly IArticleRepo _articleRepo;
            private readonly IMediator _mediator;

            public Handler(
                IArticleRepo articleRepo,
                IMediator mediator)
            {
                _articleRepo = articleRepo;
                _mediator = mediator;
            }
            public async Task<Unit> Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
            {
                var article = await _articleRepo.GetById(request.Id, cancellationToken);
                if (article == null)
                {
                    throw new NotFoundException(nameof(Article), request.Id);
                }
                await _articleRepo.Delete(article.Id, cancellationToken);
                return Unit.Value;
            }
        }
    }
}
