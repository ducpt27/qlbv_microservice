using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using VeXe.Common.Exceptions;
using VeXe.Persistence;

namespace VeXe.DTO.Request.Route
{
    public class EditRouteReq : IRequest<RouteDto>
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [Required]
        public int Id { get; set; }

        [JsonPropertyName("status")]
        public int Status { get; set; }

        [JsonPropertyName("origin_id")]
        public int OriginId { get; set; }

        public class EditRouteHandler : IRequestHandler<EditRouteReq, RouteDto>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public EditRouteHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }


            public async Task<RouteDto> Handle(EditRouteReq request, CancellationToken cancellationToken)
            {
                var entity = await _context.Routes
                    .FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Route), request.Id);
                }

                entity.Name = request.Name;
                entity.Status = request.Status;
                entity.OriginId = request.OriginId;

                await _context.SaveChangesAsync(cancellationToken);

                return _mapper.Map<RouteDto>(entity);
            }
        }
    }
}