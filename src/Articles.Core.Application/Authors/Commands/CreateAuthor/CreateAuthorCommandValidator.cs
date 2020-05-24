using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Articles.Core.Application.Authors.Commands.CreateAuthor
{
   public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.FirstName).NotNull();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.LastName).NotNull();
        }
    }
}
