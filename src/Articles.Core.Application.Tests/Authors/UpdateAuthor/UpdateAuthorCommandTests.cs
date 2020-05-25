﻿using Articles.Core.Application.Authors.Commands.UpdateAuthor;
using Articles.Core.Application.Common.Exceptions;
using Articles.Core.Application.Common.Interfaces.Contracts;
using Articles.Core.Entities;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Articles.Core.Application.Tests.Authors.UpdateAuthor
{
    public class UpdateAuthorCommandTests
    {
        [Fact]
        public async void TestCreateAuthorCommand_NotFound()
        {
            var mediator = new Mock<IMediator>();
            var authorRepo = new Mock<IAuthorRepo>();
            authorRepo.Setup(x => x.GetById(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult((Author)null));
            var updateCommand = new UpdateAuthorCommand() { Id = Guid.NewGuid(), FirstName = "Firstname", LastName = "Lastname" };
            var handler = new UpdateAuthorCommand.Handler(authorRepo.Object, mediator.Object);
            await Assert.ThrowsAsync<NotFoundException>(() => handler.Handle(updateCommand, new CancellationToken()));
        }
    }
}
