using Articles.Core.Application.Articles.Commands.CreateArticle;
using Articles.Core.Application.Common.Exceptions;
using Articles.Core.Application.Common.Interfaces.Contracts;
using Articles.Core.Entities;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using FluentValidation;
using MediatR;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Articles.Core.Application.Tests.Articles.CreateArticle
{
    [TestFixture]
    public class CreateArticleCommandTests
    {
        [Test]
        public  void TestCreateArticleCommand()
        {
            var authorId = Guid.NewGuid();
            var articleId = Guid.NewGuid();
            var heading = "heading";
            var text = "text";
            uint year = 2020;

            var author = new Author() { Id = authorId, FirstName = "Firstname", LastName = "Lastname" };

            var mediator = new Mock<IMediator>();

            var articleRepo = new Mock<IArticleRepo>();
            articleRepo.Setup(x => x.Save(It.IsAny<Article>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(new Article(author) { Id = articleId, Heading = heading, Text = text, Year = year, CreatedDate = DateTime.Now }));


            var authorRepo = new Mock<IAuthorRepo>();
            authorRepo.Setup(x => x.GetById(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(author));

            var createCommand = new CreateArticleCommand() { AuthorId = authorId, Heading = heading, Text = text, Year = year };
            var handler = new CreateArticleCommand.Handler(articleRepo.Object, authorRepo.Object, mediator.Object);          
            Assert.DoesNotThrowAsync(() => handler.Handle(createCommand, new CancellationToken()));
        }
        [Test]
        public void TestCreateArticleCommand_AuthorNotFound()
        {
            var authorId = Guid.NewGuid();
            var articleId = Guid.NewGuid();
            var heading = "";
            var text = "text";
            uint year = 2020;

            Author author = null;

            var mediator = new Mock<IMediator>();

            var articleRepo = new Mock<IArticleRepo>();        

            var authorRepo = new Mock<IAuthorRepo>();
            authorRepo.Setup(x => x.GetById(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(author));

            var createCommand = new CreateArticleCommand() { AuthorId = authorId, Heading = heading, Text = text, Year = year };
            var handler = new CreateArticleCommand.Handler(articleRepo.Object, authorRepo.Object, mediator.Object);
            Assert.ThrowsAsync<NotFoundException>(() => handler.Handle(createCommand, new CancellationToken()));
        }
    }
}
