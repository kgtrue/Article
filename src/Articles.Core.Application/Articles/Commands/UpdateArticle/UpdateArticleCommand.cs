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
        public Guid ArticleId { get; set; }
        public Guid AuthorId { get; set; }
        public string Heading { get; set; }
        public string Text { get; set; }
        public uint Year { get; set; }
        public class Handler : IRequestHandler<UpdateArticleCommand>
        {
            private readonly IArticleRepo _articleRepo;
            private readonly IMediator _mediator;

            public Handler(IArticleRepo articleRepo, IMediator mediator)
            {
                _articleRepo = articleRepo;
                _mediator = mediator;
            }
            public async Task<Unit> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
            {
                var article = await _articleRepo.GetById(request.ArticleId, cancellationToken);
                if (article == null)
                {
                    throw new NotFoundException(nameof(Article), request.ArticleId);
                }
                article.Heading = request.Heading;
                article.Text = request.Text;
                article.Year = request.Year;
                var result = await _articleRepo.Save(article, cancellationToken);
                return Unit.Value;
            }
        }
    }
}
