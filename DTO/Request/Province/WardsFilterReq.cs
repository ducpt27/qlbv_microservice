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

namespace VeXe.Dto.Request.Province
{
    public class WardsFilterReq : IRequest<List<WardDto>>
    {
        public int DistrictId { get; set; }
        public class WardsFilterHandler : IRequestHandler<WardsFilterReq, List<WardDto>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public WardsFilterHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<WardDto>> Handle(WardsFilterReq request, CancellationToken cancellationToken)
            {
                var wardDtos = await _context.Wards
                    .ProjectTo<WardDto>(_mapper.ConfigurationProvider)
                    .Where(e => e.DistrictId == request.DistrictId)
                    .ToListAsync(cancellationToken);
                return wardDtos;
            }
        }
    }
}