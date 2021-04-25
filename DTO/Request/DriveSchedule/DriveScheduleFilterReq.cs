using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VeXe.DTO;
using VeXe.Persistence;

namespace VeXe.Dto.Request.DriveSchedule
{
    public class DriveScheduleFilterReq: IRequest<List<DriveScheduleDto>>
    {

        public class DriveScheduleFilterHandler : IRequestHandler<DriveScheduleFilterReq, List<DriveScheduleDto>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public DriveScheduleFilterHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<DriveScheduleDto>> Handle(DriveScheduleFilterReq request, CancellationToken cancellationToken)
            {
                var driveScheduleDtos = await _context.DriveSchedules
                    .ProjectTo<DriveScheduleDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
                return driveScheduleDtos;
            }
        }
    }
}