using System.Collections.Generic;
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
    public class ProvincesFilterReq : IRequest<List<ProvinceDto>>
    {
        public class ProvincesFilterHandler : IRequestHandler<ProvincesFilterReq, List<ProvinceDto>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public ProvincesFilterHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<ProvinceDto>> Handle(ProvincesFilterReq request, CancellationToken cancellationToken)
            {
                var provinceDtos = await _context.Provinces
                    .ProjectTo<ProvinceDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
                return provinceDtos;
            }
        }
    }
}