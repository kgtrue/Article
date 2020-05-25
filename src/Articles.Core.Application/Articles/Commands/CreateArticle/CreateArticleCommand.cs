using Articles.Core.Application.Common.Exceptions;
using Articles.Core.Application.Common.Interfaces.Contracts;
using Articles.Core.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Articles.Core.Application.Articles.Commands.CreateArticle
{
    public class CreateArticleCommand : IRequest
    {
        public Guid AuthorId { get; set; }
        public string Heading { get; set; }
        public string Text { get; set; }
        public uint Year { get; set; }
        public class Handler : IRequestHandler<CreateArticleCommand>
        {
            private readonly IArticleRepo _articleRepo;
            private readonly IAuthorRepo _authorRepo;
            private readonly IMediator _mediator;

            public Handler(
                IArticleRepo articleRepo,
                IAuthorRepo authorRepo,
                IMediator mediator)
            {
                _articleRepo = articleRepo;
                _authorRepo = authorRepo;
                _mediator = mediator;
            }
            public async Task<Unit> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
            {
                var author = await _authorRepo.GetById(request.AuthorId, cancellationToken);
                if (author == null)
                {
                    throw new NotFoundException(nameof(Author), request.AuthorId);
                }
                var entity = new Article(author)
                {
                    Heading = request.Heading,
                    Text = request.Text,
                    Year = request.Year
                };
                var result = await _articleRepo.Save(entity, cancellationToken);
                return Unit.Value;
            }
        }
    }
}
