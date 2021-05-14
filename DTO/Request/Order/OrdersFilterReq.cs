using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VeXe.Persistence;

namespace VeXe.DTO.Request.Order
{
    public class OrdersFilterReq : IRequest<List<OrderDto>>
    {
        public class OrdersFilterHandler : IRequestHandler<OrdersFilterReq, List<OrderDto>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public OrdersFilterHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<OrderDto>> Handle(OrdersFilterReq request, CancellationToken cancellationToken)
            {
                var orderDtos = await _context.Orders
                    .ProjectTo<OrderDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
                return orderDtos;
            }
        }
    }
}