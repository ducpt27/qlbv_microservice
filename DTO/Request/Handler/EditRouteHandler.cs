using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VeXe.Common.Exceptions;
using VeXe.Domain;
using VeXe.DTO.Request.Route;
using VeXe.Persistence;

namespace VeXe.DTO.Request.Handler
{
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
                // .FindAsync(request.Id);
                .SingleOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

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