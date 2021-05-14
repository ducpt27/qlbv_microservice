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

namespace VeXe.Dto.Request.Point
{
    public class GetPointReq : IRequest<PointDto>
    {
        [JsonProperty(PropertyName = "id")] public int Id { get; set; }

        [JsonProperty(PropertyName = "origin_id")]
        public int OriginId { get; set; }

        public class GetPointHandler : IRequestHandler<GetPointReq, PointDto>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetPointHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<PointDto> Handle(GetPointReq request, CancellationToken cancellationToken)
            {
                if (request.Id != 0)
                {
                    var entity = await _context.Points
                        .ProjectTo<PointDto>(_mapper.ConfigurationProvider)
                        .Where(s => s.Id == request.Id)
                        .OrderByDescending(o => o.Id)
                        .FirstAsync();
                    if (entity == null)
                    {
                        throw new NotFoundException(nameof(Point), request.Id);
                    }
                    return _mapper.Map<PointDto>(entity);
                }

                if (request.OriginId == 0) return null;

                try
                {

                    var entity2 = await _context.Points
                        .ProjectTo<PointDto>(_mapper.ConfigurationProvider)
                        .Where(s => s.OriginId == request.OriginId)
                        .OrderByDescending(o => o.Id)
                        .FirstAsync();
                    if (entity2 == null)
                    {
                        throw new NotFoundException(nameof(Point), request.OriginId);
                    }

                    return _mapper.Map<PointDto>(entity2);
                }
                catch (Exception)
                {
                    throw new NotFoundException(nameof(Point), request.OriginId);
                }
            }
        }
    }
}