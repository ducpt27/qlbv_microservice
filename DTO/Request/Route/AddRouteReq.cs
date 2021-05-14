using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using VeXe.Common.Exceptions;
using VeXe.Domain;
using VeXe.Persistence;

namespace VeXe.DTO.Request.Route
{
    public class AddRouteReq : IRequest<RouteDto>
    {
        [JsonRequired]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonRequired]
        [JsonPropertyName("status")]
        public int Status { get; set; }

        [JsonPropertyName("origin_id")]
        public int OriginId { get; set; }

        public int[] PointIds { get; set; }
        public class AddRouteHandler : IRequestHandler<AddRouteReq, RouteDto>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
            public AddRouteHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<RouteDto> Handle(AddRouteReq request, CancellationToken cancellationToken)
            {
                var route = new Domain.Route()
                {
                    Name = request.Name,
                    Status = request.Status,
                };

                await _context.Routes.AddAsync(route);
                await _context.SaveChangesAsync(cancellationToken);
                if (route == null)
                {
                    throw new BadRequestException("Có lỗi xảy ra");
                }
                route.OriginId = request.OriginId == 0 ? route.Id : request.OriginId;

                await _context.SaveChangesAsync(cancellationToken);

                if (request.PointIds == null || request.PointIds.Length <= 0)
                    return _mapper.Map<RouteDto>(route);
                var existPointIds = request.PointIds != null && request.PointIds.Length > 0;
                try
                {
                    if (existPointIds)
                    {
                        var i = 0;
                        foreach (var pointId in request.PointIds)
                        {
                            var routePoint = new RoutePoint()
                            {
                                PointId = pointId,
                                RouteId = route.Id,
                                Position = i++
                            };
                            await _context.RoutePoints.AddAsync(routePoint);
                        }

                        await _context.SaveChangesAsync(cancellationToken);
                    }
                }
                catch (Exception)
                {
                    throw new BadRequestException("Có lỗi xảy ra");
                }
                return _mapper.Map<RouteDto>(route);
            }
        }

    }
}