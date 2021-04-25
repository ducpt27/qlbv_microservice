using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace VeXe.DTO.Request.Order.OrderItem
{
    public class OrderItemReq
    {
        [Required]
        [JsonProperty(PropertyName = "chair_id")]
        public int ChairId { get; set; }

        [Required]
        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }

        [Required]
        [JsonProperty(PropertyName = "discount")]
        public decimal Discount { get; set; }
    }
}