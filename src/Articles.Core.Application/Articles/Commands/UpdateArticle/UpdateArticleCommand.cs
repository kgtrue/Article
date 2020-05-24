using Articles.Core.Application.Common.Exceptions;
using Articles.Core.Application.Common.Interfaces.Contracts;
using Articles.Core.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Articles.Core.Application.Articles.Commands.UpdateArticle
{
    public class UpdateArticleCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
        public string Heading { get; set; }
        public string Text { get; set; }
        public uint Year { get; set; }
        public class Handler : IRequestHandler<UpdateArticleCommand>
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
            public async Task<Unit> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
            {
                var article = await _articleRepo.GetById(request.Id, cancellationToken);
                if (article == null)
                {
                    throw new NotFoundException(nameof(Article), request.Id);
                }
                var author = await _authorRepo.GetById(request.AuthorId, cancellationToken);
                if (author == null)
                {
                    throw new NotFoundException(nameof(Author), request.AuthorId);
                }
                article.Heading = request.Heading;
                article.Text = request.Text;
                article.Year = request.Year;
                article.Author = author;
                await _articleRepo.Update(article, cancellationToken);
                return Unit.Value;
            }
        }
    }
}
