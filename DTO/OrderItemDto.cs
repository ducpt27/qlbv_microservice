using AutoMapper;
using Newtonsoft.Json;
using VeXe.Common.Mapping;
using VeXe.Domain;

namespace VeXe.DTO
{
    public class OrderItemDto : IMapFrom<OrderItem>
    {
        [JsonProperty(PropertyName = "id")] public int Id { get; set; }

        [JsonProperty(PropertyName = "order_id")]
        public int OrderId { get; set; }

        [JsonProperty(PropertyName = "chair_id")]
        public int ChairId { get; set; }

        [JsonProperty(PropertyName = "price")] public decimal Price { get; set; }

        [JsonProperty(PropertyName = "discount")]
        public decimal Discount { get; set; }

        public ChairDto Chair { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrderItem, OrderItemDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
            ;
        }
    }
}