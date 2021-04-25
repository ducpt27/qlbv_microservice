using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Newtonsoft.Json;
using VeXe.DTO;
using VeXe.Persistence;

namespace VeXe.Dto.Request.DriveSchedule
{
    public class AddDriveScheduleReq : IRequest<DriveScheduleDto>
    {
        [JsonProperty(PropertyName = "user1")] public string User1 { get; set; }
        [JsonProperty(PropertyName = "user2")] public string User2 { get; set; }

        [JsonProperty(PropertyName = "route_id")]
        public int RouteId { get; set; }

        [JsonProperty(PropertyName = "car_id")]
        public int CarId { get; set; }

        [JsonProperty(PropertyName = "total_time")]
        public int TotalTime { get; set; }

        [JsonProperty(PropertyName = "price")] public decimal Price { get; set; }
        [JsonProperty(PropertyName = "note")] public string Note { get; set; }

        [JsonProperty(PropertyName = "total_chairs_remain")]
        public int TotalChairsRemain { get; set; }

        [JsonProperty(PropertyName = "status")]
        public int Status { get; set; }

        [JsonProperty(PropertyName = "drive_point")]
        public IList<DrivePointDto> DrivePointDtos { get; set; }

        [JsonProperty(PropertyName = "drive_time")]
        public IList<DriveTimeDto> DriveTimeDtos { get; set; }

        [JsonProperty(PropertyName = "chair_schedule")]
        public IList<ChairScheduleDto> ChairScheduleDtos { get; set; }

        [JsonProperty(PropertyName = "car")] public CarDto CarDto { get; set; }

        public class AddDriveScheduleHandler : IRequestHandler<AddDriveScheduleReq, DriveScheduleDto>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public AddDriveScheduleHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public Task<DriveScheduleDto> Handle(AddDriveScheduleReq request, CancellationToken cancellationToken)
            {
                Console.WriteLine(JsonConvert.SerializeObject(request));
                throw new System.NotImplementedException();
            }
        }
    }
}