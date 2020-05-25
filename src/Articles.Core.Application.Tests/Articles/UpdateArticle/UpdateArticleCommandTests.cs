using Articles.Core.Application.Articles.Commands.UpdateArticle;
using Articles.Core.Application.Common.Exceptions;
using Articles.Core.Application.Common.Interfaces.Contracts;
using Articles.Core.Entities;
using MediatR;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Articles.Core.Application.Tests.Articles.UpdateArticle
{
    [TestFixture]
    public class UpdateArticleCommandTests
    {
        [Test]
        public void TestUpdateArticleCommand_ArticleNotFound()
        {
            var mediator = new Mock<IMediator>();

            var articleRepo = new Mock<IArticleRepo>();
            articleRepo.Setup(x => x.GetById(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult((Article)null));

            var author = new Author() { Id = Guid.NewGuid(), FirstName = "Firstname", LastName = "Lastname" };
            var authorRepo = new Mock<IAuthorRepo>();
            authorRepo.Setup(x => x.GetById(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(author));

            var updateCommand = new UpdateArticleCommand() { Id = Guid.NewGuid(), AuthorId = author.Id, Heading = "heading", Text = "Text", Year = 2020 };
            var handler = new UpdateArticleCommand.Handler(articleRepo.Object, authorRepo.Object, mediator.Object);
            Assert.ThrowsAsync<NotFoundException>(() => handler.Handle(updateCommand, new CancellationToken()));
        }
        [Test]
        public void TestUpdateArticleCommand_AuthorNotFound()
        {
            var mediator = new Mock<IMediator>();

            var articleRepo = new Mock<IArticleRepo>();
            articleRepo.Setup(x => x.GetById(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(new Article(
                new Author()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Firstname",
                    LastName = "Lastname"
                })
            {
                Id = Guid.NewGuid(),
                Heading = "Heading",
                Text = "Text",
                Year = 2020
            }));
            var authorRepo = new Mock<IAuthorRepo>();
            authorRepo.Setup(x => x.GetById(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult((Author)null));

            var updateCommand = new UpdateArticleCommand() { Id = Guid.NewGuid(), AuthorId = Guid.NewGuid(), Heading = "heading", Text = "Text", Year = 2020 };
            var handler = new UpdateArticleCommand.Handler(articleRepo.Object, authorRepo.Object, mediator.Object);
            Assert.ThrowsAsync<NotFoundException>(() => handler.Handle(updateCommand, new CancellationToken()));
        }
    }
}
