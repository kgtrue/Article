using Articles.Core.Application.Articles.Commands.DeleteArticle;
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

namespace Articles.Core.Application.Tests.Articles.DeleteArticle
{
    [TestFixture]
    public class DeleteArticleCommandTests
    {
        [Test]
        public void TestDeleteArticleCommand_NotFound()
        {
            var mediator = new Mock<IMediator>();
            var articleRepo = new Mock<IArticleRepo>();           
            articleRepo.Setup(x => x.GetById(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult((Article)null));
            var deleteCommand = new DeleteArticleCommand() { Id = Guid.NewGuid() };
            var handler = new DeleteArticleCommand.Handler(articleRepo.Object, mediator.Object);
            Assert.ThrowsAsync<NotFoundException>(() => handler.Handle(deleteCommand, new CancellationToken()));
        }
    }
}
