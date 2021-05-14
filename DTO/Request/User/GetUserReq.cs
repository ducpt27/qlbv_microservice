using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using VeXe.Common.Exceptions;
using VeXe.DTO;
using VeXe.Persistence;

namespace VeXe.Dto.Request.User
{
    public class GetUserReq : IRequest<UserDto>
    {
        [JsonProperty(PropertyName = "id")] public int Id { get; set; }

        public class GetUserHandler : IRequestHandler<GetUserReq, UserDto>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetUserHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<UserDto> Handle(GetUserReq request, CancellationToken cancellationToken)
            {
                var entity = await _context.Users
                    .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                    .Where(s => s.Id == request.Id)
                    .OrderByDescending(o => o.Id)
                    .FirstAsync();
                if (entity == null)
                {
                    throw new NotFoundException(nameof(User), request.Id);
                }
                return _mapper.Map<UserDto>(entity);
            }
        }
    }
}