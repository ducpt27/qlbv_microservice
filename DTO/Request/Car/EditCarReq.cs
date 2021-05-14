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

namespace VeXe.DTO.Request.Car
{
    public class EditCarReq : IRequest<CarDto>
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "origin_id")]
        public int OriginId { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "total_chairs")]
        public int TotalChairs { get; set; }
        [JsonProperty(PropertyName = "total_floors")]
        public int TotalFloors { get; set; }
        [JsonProperty(PropertyName = "total_rows")]
        public int TotalRows { get; set; }
        [JsonProperty(PropertyName = "total_cols")]
        public int TotalCols { get; set; }
        [JsonProperty(PropertyName = "note")]
        public string Note { get; set; }
        [JsonProperty(PropertyName = "status")]
        public int Status { get; set; }

        public class EditCarHandler : IRequestHandler<EditCarReq, CarDto>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public EditCarHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }


            public async Task<CarDto> Handle(EditCarReq request, CancellationToken cancellationToken)
            {
                var entity = await _context.Cars
                    .FindAsync(request.Id);
                if (entity == null)
                {
                    throw new NotFoundException(nameof(Car), request.Id);
                }

                entity.Name = request.Name;
                entity.Status = request.Status;
                entity.Note = request.Note;
                entity.OriginId = request.OriginId;

                await _context.SaveChangesAsync(cancellationToken);

                return await _context.Cars
                    .ProjectTo<CarDto>(_mapper.ConfigurationProvider)
                    .Where(e => e.Id == request.Id)
                    .FirstAsync();
            }
        }
    }
}