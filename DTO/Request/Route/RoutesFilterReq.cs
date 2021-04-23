using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VeXe.Persistence;

namespace VeXe.DTO.Request.Route
{
    public class RoutesFilterReq: IRequest<List<RouteDto>>
    {
        public class RoutesFilterHandler : IRequestHandler<RoutesFilterReq, List<RouteDto>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public RoutesFilterHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<RouteDto>> Handle(RoutesFilterReq request, CancellationToken cancellationToken)
            {
                var routeDtos = await _context.Routes
                    .ProjectTo<RouteDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
                return routeDtos;
            }
        }
    }
}