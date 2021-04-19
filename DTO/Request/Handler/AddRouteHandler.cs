using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Newtonsoft.Json;
using VeXe.Common.Exceptions;
using VeXe.Domain;
using VeXe.Dto.Request;
using VeXe.Persistence;

namespace VeXe.DTO.Request.Handler
{
    public class AddRouteHandler : IRequestHandler<RouteReq, RouteDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AddRouteHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RouteDto> Handle(RouteReq request, CancellationToken cancellationToken)
        {
            var route = new Route()
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
            if (request.PointIds == null || request.PointIds.Length <= 0) 
                return _mapper.Map<RouteDto>(route);
            var existPointIds = request.PointIds != null && request.PointIds.Length > 0;
            try
            {
                if (existPointIds)
                {
                    foreach (var pointId in request.PointIds)
                    {
                        var routePoint = new RoutePoint
                        {
                            PointId = pointId,
                            RouteId = route.Id
                        };
                        await _context.RoutePoints.AddAsync(routePoint);
                    }

                    await _context.SaveChangesAsync(cancellationToken);
                }
            }
            catch (Exception ex)
            {
                throw new BadRequestException("Có lỗi xảy ra");
            }
            return _mapper.Map<RouteDto>(route);
        }
    }
}