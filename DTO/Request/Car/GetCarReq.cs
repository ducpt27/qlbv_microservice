using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using VeXe.Common.Exceptions;
using VeXe.DTO;
using VeXe.Persistence;

namespace VeXe.Dto.Request.Car
{
    public class GetCarReq: IRequest<CarDto>
    {
        [JsonProperty(PropertyName = "id")] public int Id { get; set; }

        [JsonProperty(PropertyName = "origin_id")]
        public int OriginId { get; set; }
        
        public class GetCarHandler: IRequestHandler<GetCarReq, CarDto>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetCarHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<CarDto> Handle(GetCarReq request, CancellationToken cancellationToken)
            {
                if (request.Id != 0)
                {
                    var entity = await _context.Cars
                        .ProjectTo<CarDto>(_mapper.ConfigurationProvider)
                        .Where(s => s.Id == request.Id)
                        .OrderByDescending(o => o.Id)
                        .FirstAsync();
                    if (entity == null)
                    {
                        throw new NotFoundException(nameof(Car), request.Id);
                    }
                    return _mapper.Map<CarDto>(entity);
                }

                if (request.OriginId == 0) return null;

                try
                {

                    var entity2 = await _context.Cars
                        .ProjectTo<CarDto>(_mapper.ConfigurationProvider)
                        .Where(s => s.OriginId == request.OriginId)
                        .OrderByDescending(o => o.Id)
                        .FirstAsync();
                    if (entity2 == null)
                    {
                        throw new NotFoundException(nameof(Car), request.OriginId);
                    }

                    return _mapper.Map<CarDto>(entity2);
                }
                catch (Exception)
                {
                    throw new NotFoundException(nameof(Car), request.OriginId);
                }
            }
        }
    }
}