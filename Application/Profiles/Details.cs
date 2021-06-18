using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Application.Profiles
{
    public class Details
    {
        public class Query : IRequest<Result<Profile>>
        {
            public string UserName { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<Profile>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            private readonly IUserAccessor _userAccessor;
            public Handler(DataContext context, IMapper mapper, IUserAccessor userAccessor)
            {
                this._userAccessor = userAccessor;
                this._mapper = mapper;
                this._context = context;
            }

            public async Task<Result<Profile>> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _context.Users
                        .ProjectTo<Profile>(_mapper.ConfigurationProvider, new{currentUsername = _userAccessor.getUsername()})
                        .SingleOrDefaultAsync(x => x.Username == request.UserName);
                if (user == null) return null;
                return Result<Profile>.Success(user);
            }
        }
    }
}