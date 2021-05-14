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

namespace VeXe.DTO.Request.Car
{
    public class AddCarReq : IRequest<CarDto>
    {
        [JsonProperty(PropertyName = "id")] public int Id { get; set; }

        [JsonProperty(PropertyName = "origin_id")]
        public int OriginId { get; set; }

        [JsonProperty(PropertyName = "name")] public string Name { get; set; }

        [JsonProperty(PropertyName = "total_chairs")]
        public int TotalChairs { get; set; }

        [JsonProperty(PropertyName = "total_floors")]
        public int TotalFloors { get; set; }

        [JsonProperty(PropertyName = "total_rows")]
        public int TotalRows { get; set; }

        [JsonProperty(PropertyName = "total_cols")]
        public int TotalCols { get; set; }

        [JsonProperty(PropertyName = "status")]
        public int Status { get; set; }

        [JsonProperty(PropertyName = "note")] public string Note { get; set; }

        [JsonProperty(PropertyName = "chairs")]
        public IList<ChairDto> Chairs { get; set; }

        public class AddCarHandler : IRequestHandler<AddCarReq, CarDto>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public AddCarHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<CarDto> Handle(AddCarReq request, CancellationToken cancellationToken)
            {
                var car = new Domain.Car()
                {
                    Name = request.Name,
                    TotalChairs = request.Chairs.Count,
                    Note = request.Note,
                    TotalCols = request.TotalCols,
                    TotalRows = request.TotalRows,
                    TotalFloors = request.TotalFloors,
                    Status = request.Status
                };
                await _context.Cars.AddAsync(car);
                await _context.SaveChangesAsync(cancellationToken);

                car.OriginId = request.OriginId == 0 ? car.Id : request.OriginId;

                if (request.Chairs != null || request.Chairs.Count > 0)
                {
                    foreach (var chairReq in request.Chairs)
                    {
                        var chair = new Chair()
                        {
                            CarId = car.Id,
                            Col = chairReq.Col,
                            Row = chairReq.Row,
                            Floor = chairReq.Floor
                        };
                        await _context.Chairs.AddAsync(chair);
                    }
                }

                await _context.SaveChangesAsync(cancellationToken);
                return _mapper.Map<CarDto>(car);
            }
        }
    }
}