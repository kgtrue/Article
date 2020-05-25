using Articles.Core.Application.Authors.Commands.CreateAuthor;
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


namespace Articles.Core.Application.Tests.Authors.CreateAuthor
{
    public class CreateAuthorCommandTests
    {
        [Test]
        public void TestCreateAuthorCommand()
        {
            var mediator = new Mock<IMediator>();
            var authorRepo = new Mock<IAuthorRepo>();
            authorRepo.Setup(x => x.Save(It.IsAny<Author>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(new Author() { Id = Guid.NewGuid(), FirstName = "Firstname", LastName = "Lastname" }));

            var createCommand = new CreateAuthorCommand() { FirstName = "Firstname", LastName = "Lastname" };
            var handler = new CreateAuthorCommand.Handler(authorRepo.Object, mediator.Object);
            Assert.DoesNotThrowAsync(() => handler.Handle(createCommand, new CancellationToken()));
        }
    }
}
