using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Articles.Core.Application.Articles.Commands.UpdateArticle
{
    public class UpdateArticleCommandValidator : AbstractValidator<UpdateArticleCommand>
    {
        public UpdateArticleCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.AuthorId).NotEmpty();
            RuleFor(x => x.Heading).NotEmpty();
            RuleFor(x => x.Text).NotEmpty();
            RuleFor(x => x.Year).NotEmpty();
        }
    }
}
