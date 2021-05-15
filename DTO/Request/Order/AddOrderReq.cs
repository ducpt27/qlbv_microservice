using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Newtonsoft.Json;
using VeXe.Common.Exceptions;
using VeXe.DTO.Request.Order.OrderItem;
using VeXe.Persistence;

namespace VeXe.DTO.Request.Order
{
    public class AddOrderReq : IRequest<OrderDto>
    {
        [JsonRequired]
        [JsonProperty(PropertyName = "drive_schedule_id")]
        public int DriveScheduleId { get; set; }

        [JsonRequired]
        [JsonProperty(PropertyName = "discount")]
        public decimal Discount { get; set; }

        [JsonProperty(PropertyName = "mobile")]
        public string Mobile { get; set; }

        [JsonProperty(PropertyName = "full_name")]
        public string FullName { get; set; }

        [JsonProperty(PropertyName = "age")] public int Age { get; set; }

        [JsonRequired]
        [JsonProperty(PropertyName = "status")]
        public int Status { get; set; }

        [JsonRequired]
        [JsonProperty(PropertyName = "payment_status")]
        public int PaymentStatus { get; set; }

        [JsonRequired]
        [JsonProperty(PropertyName = "point_id_start")]
        public int PointIdStart { get; set; }

        [JsonRequired]
        [JsonProperty(PropertyName = "point_id_end")]
        public int PointIdEnd { get; set; }

        [JsonRequired]
        [JsonProperty(PropertyName = "order_items")]
        public IList<OrderItemReq> OrderItemLists { get; set; }

        public class AddCarHandler : IRequestHandler<AddOrderReq, OrderDto>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public AddCarHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<OrderDto> Handle(AddOrderReq request, CancellationToken cancellationToken)
            {
                try
                {
                    var transaction = _context.Database.BeginTransaction();
                    var order = new Domain.Order()
                    {
                        Discount = request.Discount,
                        FullName = request.FullName,
                        Age = request.Age,
                        Mobile = request.Mobile,
                        Status = request.Status,
                        PaymentStatus = request.PaymentStatus,
                        DriveScheduleId = request.DriveScheduleId,
                        PointIdStart = request.PointIdStart,
                        PointIdEnd = request.PointIdEnd,
                        Code = request.Mobile,
                        Price = 0
                    };
                    await _context.Orders.AddAsync(order, cancellationToken);
                    await _context.SaveChangesAsync(cancellationToken);

                    var driveSchedule = await _context.DriveSchedules
                    .FindAsync(request.DriveScheduleId);
                    if (driveSchedule == null)
                    {
                        throw new NotFoundException(nameof(DriveSchedule), request.DriveScheduleId);
                    }
                    driveSchedule.TotalChairsRemain = driveSchedule.TotalChairsRemain - 1;
                    await _context.SaveChangesAsync(cancellationToken);


                    var totalPrice = Decimal.Zero;
                    if (request.OrderItemLists == null || request.OrderItemLists.Count <= 0)
                    {
                        throw new BadRequestException("Chọn ít nhất 1 ghế");
                    }
                    else
                    {
                        foreach (var item in request.OrderItemLists)
                        {
                            CheckChair(item.ChairId, order.DriveScheduleId);
                            totalPrice = Decimal.Add(totalPrice, item.Price);
                            var orderItem = new Domain.OrderItem()
                            {
                                Discount = item.Discount,
                                Price = item.Price,
                                ChairId = item.ChairId,
                                OrderId = order.Id,
                                DriveScheduleId = order.DriveScheduleId
                            };
                            await _context.OrderItems.AddAsync(orderItem, cancellationToken);
                        }
                    }

                    order.Price = totalPrice;
                    await _context.SaveChangesAsync(cancellationToken);

                    transaction.Commit();
                    return _mapper.Map<OrderDto>(order);
                }
                catch (Exception ex)
                {
                    throw new BadRequestException(ex.Message);
                }
            }

            public void CheckChair(int chairId, int driveScheduleId)
            {
                var orderItem = _context.OrderItems.SingleOrDefault(i =>
                    i.ChairId == chairId && i.DriveScheduleId == driveScheduleId);
                if (orderItem != null)
                {
                    throw new BadRequestException("Ghế đã được bán");
                }
            }
        }
    }
}