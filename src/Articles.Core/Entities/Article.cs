using Articles.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Articles.Core.Entities
{
    public class Article : BaseEntity<Article, Guid>
    {
        public Article()
        {

        } 
        public string Heading { get; set; }
        public string Text { get; set; }
        public uint Year { get; set; }
        public Author Author { get; set; }
    }
}
