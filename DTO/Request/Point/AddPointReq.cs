using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Newtonsoft.Json;
using VeXe.Common.Exceptions;
using VeXe.DTO;
using VeXe.Persistence;

namespace VeXe.Dto.Request.Point
{
    public class AddPointReq : IRequest<PointDto>
    {


        [JsonProperty(PropertyName = "origin_id")]
        public int OriginId { get; set; }

        [JsonProperty(PropertyName = "street")]
        public string Street { get; set; }

        [JsonRequired]
        [JsonProperty(PropertyName = "province_id")]
        public int ProvinceId { get; set; }

        [JsonRequired]
        [JsonProperty(PropertyName = "district_id")]
        public int DistrictId { get; set; }

        [JsonRequired]
        [JsonProperty(PropertyName = "ward_id")]
        public int WardId { get; set; }

        [JsonRequired]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonRequired]
        [JsonProperty(PropertyName = "status")]
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

                point.OriginId = request.OriginId == 0 ? point.Id : request.OriginId;

                await _context.SaveChangesAsync(cancellationToken);
                return _mapper.Map<PointDto>(point);
            }
        }
    }
}