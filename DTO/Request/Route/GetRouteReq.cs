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
using VeXe.Persistence;

namespace VeXe.DTO.Request.Route
{
    public class GetRouteReq : IRequest<RouteDto>
    {
        [JsonProperty(PropertyName = "id")] public int Id { get; set; }

        [JsonProperty(PropertyName = "origin_id")]
        public int OriginId { get; set; }

        public class GetRouteHandler : IRequestHandler<GetRouteReq, RouteDto>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetRouteHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<RouteDto> Handle(GetRouteReq request, CancellationToken cancellationToken)
            {
                if (request.Id != 0)
                {
                    var entity = await _context.Routes
                        .ProjectTo<RouteDto>(_mapper.ConfigurationProvider)
                        .Where(s => s.Id == request.Id)
                        .OrderByDescending(o => o.Id)
                        .FirstAsync();
                    if (entity == null)
                    {
                        throw new NotFoundException(nameof(Route), request.Id);
                    }
                    return _mapper.Map<RouteDto>(entity);
                }

                if (request.OriginId == 0) return null;

                try
                {

                    var entity2 = await _context.Routes
                        .ProjectTo<RouteDto>(_mapper.ConfigurationProvider)
                        .Where(s => s.OriginId == request.OriginId)
                        .OrderByDescending(o => o.Id)
                        .FirstAsync();
                    if (entity2 == null)
                    {
                        throw new NotFoundException(nameof(Route), request.OriginId);
                    }

                    return _mapper.Map<RouteDto>(entity2);
                }
                catch (Exception)
                {
                    throw new NotFoundException(nameof(Route), request.OriginId);
                }
            }
        }
    }
}