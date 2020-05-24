using Articles.Core.Application.Common.Interfaces.Contracts;
using Articles.Core.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Articles.Core.Application.Authors.Queries.GetAuthorsList
{
    public class GetAuthorsListQueryHandler : IRequestHandler<GetAuthorsListQuery, GetAuthorListVM>
    {
        private readonly IAuthorRepo _authorRepo;
        private readonly IMapper _mapper;
        public GetAuthorsListQueryHandler(
            IAuthorRepo authorRepo,
            IMapper mapper)
        {
            _authorRepo = authorRepo;
            _mapper = mapper;
        }
        public async Task<GetAuthorListVM> Handle(GetAuthorsListQuery request, CancellationToken cancellationToken)
        {
            var result = new GetAuthorListVM()
            {
                Authors = _mapper.Map<IEnumerable<Author>, IEnumerable<AuthorLookupDto>>(await _authorRepo.GetAll(cancellationToken))
            };
            return result;
        }
    }
}
