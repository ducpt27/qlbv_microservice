using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VeXe.Persistence;

namespace VeXe.DTO.Request.User
{
    public class UsersFilterReq : IRequest<List<UserDto>>
    {
        public class UsersFilterHandler : IRequestHandler<UsersFilterReq, List<UserDto>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public UsersFilterHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<UserDto>> Handle(UsersFilterReq request, CancellationToken cancellationToken)
            {
                var dtos = await _context.Users
                    .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                    .Where(e => e.Status != 2)
                    .ToListAsync(cancellationToken);
                return dtos;
            }
        }
    }
}