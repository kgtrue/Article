using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Articles.Core.Application.Articles.Commands.CreateArticle
{
    public class CreateArticleCommandValidator : AbstractValidator<CreateArticleCommand>
    {
        public CreateArticleCommandValidator()
        {
            RuleFor(x => x.AuthorId).NotEmpty();
            RuleFor(x => x.Heading).NotEmpty();
            RuleFor(x => x.Text).NotEmpty();
            RuleFor(x => x.Year).NotEmpty();
        }

    }
}
