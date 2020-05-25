using Articles.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Articles.Core.Exceptions;

namespace Articles.Core.Entities
{
    public class Article : BaseEntity<Article, Guid>
    {
        internal Article() { }
        public Article(Author author)
        {
            _ = author ?? throw new NullReferenceException("Author cannot be null");
            if (string.IsNullOrEmpty(author.FirstName)) throw new CoreValidationException("Author firstname is not valid name");
            if (string.IsNullOrEmpty(author.LastName)) throw new CoreValidationException("Author lastname is not valid name");
            Author = author;
        }
        public string Heading { get; set; }
        public string Text { get; set; }
        public uint Year { get; set; }
        public Author Author { get; private set; }
        public void SetArticleAuthor(Author author)
        {
            if (string.IsNullOrEmpty(author.FirstName))
            {
                throw new CoreValidationException($"Entity \"{nameof(Author)}\" ({Author.Id}) firstname is not valid name ({this.Id}).");
            }
            if (string.IsNullOrEmpty(author.LastName))
            {
                throw new CoreValidationException($"Entity \"{nameof(Author)}\" ({Author.Id}) lastname is not valid name ({this.Id}).");
            }
            Author = author;
        }
    }
}
