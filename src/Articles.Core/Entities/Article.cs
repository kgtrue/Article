using Articles.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Articles.Core.Entities
{
    public class Article : BaseEntity<Article, Guid>
    {
        public Article(Author author)
        {
            _ = author ?? throw new NullReferenceException("Author cannot be null");
            Author = author;
        }
        public string Heading { get; set; }
        public string Text { get; set; }
        public uint Year { get; set; }
        public Author Author { get; private set; }
    }
}
