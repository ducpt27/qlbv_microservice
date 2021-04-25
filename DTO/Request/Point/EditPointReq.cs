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
    public class EditPointReq : IRequest<PointDto>
    {
      
        [JsonPropertyName("street")]
        public string Street { get; set; }
        
        [Required]
        public int Id { get; set; }
        [Required]
        [JsonPropertyName("province_id")]
        public int ProvinceId { get; set; }
        
        [Required]
        [JsonPropertyName("district_id")]
        public int DistrictId { get; set; }
        
        [Required]
        [JsonPropertyName("ward_id")]
        public int WardId { get; set; }
       
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [Required]
        [JsonPropertyName("status")]
        public int Status { get; set; }
        
        public class EditPointHandler : IRequestHandler<EditPointReq, PointDto>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public EditPointHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }


            public async Task<PointDto> Handle(EditPointReq request, CancellationToken cancellationToken)
            {
                var entity = await _context.Points
                    .FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Point), request.Id);
                }

                entity.Name = request.Name;
                entity.Status = request.Status;
                entity.Street = request.Street;
                entity.ProvinceId = request.ProvinceId;
                entity.DistrictId = request.DistrictId;
                entity.WardId = request.WardId;
                
                await _context.SaveChangesAsync(cancellationToken);

                return _mapper.Map<PointDto>(entity);
            }
        }
    }
}