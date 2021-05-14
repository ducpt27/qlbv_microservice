using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VeXe.DTO;
using VeXe.Persistence;

namespace VeXe.Dto.Request.Point
{
    public class PointsFilterReq : IRequest<List<PointDto>>
    {
        public class PointsFilterHandler : IRequestHandler<PointsFilterReq, List<PointDto>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public PointsFilterHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<PointDto>> Handle(PointsFilterReq request, CancellationToken cancellationToken)
            {
                var carDtos = await _context.Points
                    .ProjectTo<PointDto>(_mapper.ConfigurationProvider)
                    .Where(e => e.Status != 2)
                    .ToListAsync(cancellationToken);
                return carDtos;
            }
        }
    }
}