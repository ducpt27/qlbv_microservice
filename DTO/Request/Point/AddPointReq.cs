using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using VeXe.Common.Exceptions;
using VeXe.DTO;
using VeXe.Persistence;

namespace VeXe.Dto.Request.Point
{
    public class AddPointReq : IRequest<PointDto>
    {

        [JsonPropertyName("street")]
        public string Street { get; set; }

        [Required]
        [JsonPropertyName("province_id")]
        public int ProvinceId { get; set; }

        [Required]
        [JsonPropertyName("district_id")]
        public int DistrictId { get; set; }

        [Required]
        [JsonPropertyName("ward_id")]
        public int WardId { get; set; }

        [Required]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [Required]
        [JsonPropertyName("status")]
        public int Status { get; set; }


        public class AddPointHandler : IRequestHandler<AddPointReq, PointDto>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public AddPointHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<PointDto> Handle(AddPointReq request, CancellationToken cancellationToken)
            {
                var point = new Domain.Point()
                {
                    Name = request.Name,
                    Status = request.Status,
                    Street = request.Street,
                    ProvinceId = request.ProvinceId,
                    DistrictId = request.DistrictId,
                    WardId = request.WardId
                };

                await _context.Points.AddAsync(point);
                await _context.SaveChangesAsync(cancellationToken);
                return _mapper.Map<PointDto>(point);

                // route.OriginId = request.OriginId == 0 ? route.Id : request.OriginId;
                // if (request.PointIds == null || request.PointIds.Length <= 0) 
                //     return _mapper.Map<RouteDto>(route);
                // var existPointIds = request.PointIds != null && request.PointIds.Length > 0;
                // try
                // {
                // if (existPointIds)
                // {
                //     foreach (var pointId in request.PointIds)
                //     {
                //         var routePoint = new RoutePoint()
                //         {
                //             PointId = pointId,
                //             RouteId = route.Id
                //         };
                //         await _context.RoutePoints.AddAsync(routePoint);
                //     }
                //
                //     await _context.SaveChangesAsync(cancellationToken);
                // }
                // }
                // catch (Exception ex)
                // {
                //     throw new BadRequestException("Có lỗi xảy ra");
                // }

            }
        }
    }
}