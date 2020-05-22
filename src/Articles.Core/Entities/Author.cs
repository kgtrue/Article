using Articles.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Articles.Core.Entities
{
    public class Author: BaseEntity<Author, Guid>
    {
        private IList<Article> _articles;
        public Author()
        {
            _articles = new List<Article>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<Article> Articles { get=>_articles; }       
    }
}
