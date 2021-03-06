using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Newtonsoft.Json;
using VeXe.Common.Exceptions;
using VeXe.Domain;
using VeXe.Persistence;

namespace VeXe.DTO.Request.DriveSchedule
{
    public class AddDriveScheduleReq : IRequest<DriveScheduleDto>
    {
        [JsonProperty(PropertyName = "user1")] public string User1 { get; set; }
        [JsonProperty(PropertyName = "user2")] public string User2 { get; set; }

        [JsonRequired]

        [JsonProperty(PropertyName = "route_id")]
        public int RouteId { get; set; }

        [JsonRequired]

        [JsonProperty(PropertyName = "car_id")]
        public int CarId { get; set; }

        [JsonRequired]

        [JsonProperty(PropertyName = "total_time")]
        public int TotalTime { get; set; }

        [JsonRequired]

        [JsonProperty(PropertyName = "price")] public decimal Price { get; set; }
        [JsonProperty(PropertyName = "note")] public string Note { get; set; }

        [JsonProperty(PropertyName = "status")]
        [JsonRequired]
        public int Status { get; set; }

        [JsonProperty(PropertyName = "drive_prices")]
        public IList<DrivePriceDto> DrivePrices { get; set; }

        [JsonProperty(PropertyName = "drive_points")]
        public IList<DrivePointDto> DrivePoints { get; set; }

        public class AddDriveScheduleHandler : IRequestHandler<AddDriveScheduleReq, DriveScheduleDto>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public AddDriveScheduleHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<DriveScheduleDto> Handle(AddDriveScheduleReq request, CancellationToken cancellationToken)
            {
                try
                {
                    var transaction = _context.Database.BeginTransaction();
                    var driveSchedule = new Domain.DriveSchedule()
                    {
                        Note = request.Note,
                        Price = request.Price,
                        User1 = request.User1,
                        User2 = request.User2,
                        Status = request.Status,
                        RouteId = request.RouteId,
                        CarId = request.CarId,
                        TotalTime = request.TotalTime
                    };
                    await _context.DriveSchedules.AddAsync(driveSchedule);
                    await _context.SaveChangesAsync(cancellationToken);


                    var car = await _context.Cars
                    .FindAsync(request.CarId);
                    if (car == null)
                    {
                        throw new NotFoundException(nameof(Car), request.CarId);
                    }
                    driveSchedule.TotalChairsRemain = car.TotalChairs;

                    if (request.DrivePrices != null && request.DrivePrices.Count > 0)
                    {
                        foreach (var item in request.DrivePrices)
                        {
                            var drivePrice = new DrivePrice
                            {
                                Price = item.Price,
                                DriveScheduleId = driveSchedule.Id,
                                PointIdStart = item.PointIdStart,
                                PointIdEnd = item.PointIdEnd
                            };
                            await _context.DrivePrices.AddAsync(drivePrice);
                        }
                    }

                    if (request.DrivePoints != null && request.DrivePoints.Count > 0)
                    {
                        foreach (var item in request.DrivePoints)
                        {
                            var drivePoint = new DrivePoint
                            {
                                PointId = item.PointId,
                                TimeStart = Convert.ToDateTime(item.TimeStart),
                                DriveScheduleId = driveSchedule.Id,
                            };
                            await _context.DrivePoints.AddAsync(drivePoint);
                        }
                    }

                    await _context.SaveChangesAsync(cancellationToken);
                    transaction.Commit();
                    return _mapper.Map<DriveScheduleDto>(driveSchedule);
                }
                catch (Exception e)
                {
                    throw new BadRequestException(e.Message);
                }
            }
        }
    }
}