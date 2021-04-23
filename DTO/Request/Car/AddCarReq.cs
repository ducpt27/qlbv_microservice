using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Newtonsoft.Json;

namespace VeXe.DTO.Request.Car
{
    public class AddCarReq : IRequest<CarDto> 
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
        
        public class AddCarHandler: IRequestHandler<AddCarReq, CarDto>
        {
            public AddCarHandler()
            {
            }
            public Task<CarDto> Handle(AddCarReq request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}