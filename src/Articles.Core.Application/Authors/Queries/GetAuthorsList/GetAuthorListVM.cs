using System;
using System.Collections.Generic;
using System.Text;

namespace Articles.Core.Application.Authors.Queries.GetAuthorsList
{
   public class GetAuthorListVM
    {
        public IEnumerable<AuthorLookupDto> Authors { get; set; }
    }
}
