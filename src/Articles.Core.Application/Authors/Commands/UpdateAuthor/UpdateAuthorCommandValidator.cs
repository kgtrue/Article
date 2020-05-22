using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Articles.Core.Application.Authors.Commands.UpdateAuthor
{
  public  class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(x => x.AuthorId).NotEmpty();
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
        }
    }
}
