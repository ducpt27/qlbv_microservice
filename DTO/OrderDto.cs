using System.Globalization;
using AutoMapper;
using Newtonsoft.Json;
using VeXe.Common.Mapping;
using VeXe.Domain;

namespace VeXe.DTO
{
    public class OrderDto : IMapFrom<Order>
    {
        [JsonProperty(PropertyName = "id")] public int Id { get; set; }

        [JsonProperty(PropertyName = "drive_schedule_id")]
        public int DriveScheduleId { get; set; }

        [JsonProperty(PropertyName = "code")] public string Code { get; set; }
        [JsonProperty(PropertyName = "price")] public decimal Price { get; set; }

        [JsonProperty(PropertyName = "discount")]
        public decimal Discount { get; set; }

        [JsonProperty(PropertyName = "mobile")]
        public string Mobile { get; set; }

        [JsonProperty(PropertyName = "full_name")]
        public string FullName { get; set; }

        [JsonProperty(PropertyName = "age")] public int Age { get; set; }

        [JsonProperty(PropertyName = "status")]
        public int Status { get; set; }

        [JsonProperty(PropertyName = "payment_status")]
        public int PaymentStatus { get; set; }

        [JsonProperty(PropertyName = "point_id_start")]
        public int PointIdStart { get; set; }

        [JsonProperty(PropertyName = "point_id_end")]
        public int PointIdEnd { get; set; }

        [JsonProperty(PropertyName = "created_by")]
        public string CreatedBy { get; set; }

        [JsonProperty(PropertyName = "created_on")]
        public string CreatedOn { get; set; }

        [JsonProperty(PropertyName = "modified_by")]
        public string ModifiedBy { get; set; }

        [JsonProperty(PropertyName = "modified_on")]
        public string ModifiedOn { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(x => x.CreatedOn,
                    opt => opt.MapFrom(src => (src.CreatedOn).ToString(CultureInfo.InvariantCulture)))
                .ForMember(x => x.ModifiedOn,
                    opt => opt.MapFrom(src => (src.ModifiedOn).ToString(CultureInfo.InvariantCulture)));
            ;
        }
    }
}