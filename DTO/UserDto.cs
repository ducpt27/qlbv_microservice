using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Globalization;
using VeXe.Common.Mapping;
using VeXe.Domain;

namespace VeXe.DTO
{
    public class UserDto : IMapFrom<User>
    {
        [JsonProperty(PropertyName = "id")] public int Id { get; set; }
        public string Email { get; set; }
        [JsonProperty(PropertyName = "full_name")] public string FullName { get; set; }
        public string Mobile { get; set; }
        public int Age { get; set; }
        public string Note { get; set; }
        [JsonProperty(PropertyName = "group_id")] public int GroupId { get; set; }
        public DateTime BirthDate { get; set; }
        public int Status { get; set; }

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
            profile.CreateMap<User, UserDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(x => x.CreatedOn,
                    opt => opt.MapFrom(src => ((DateTime)src.CreatedOn).ToString(CultureInfo.InvariantCulture)))
                .ForMember(x => x.ModifiedOn,
                    opt => opt.MapFrom(src => ((DateTime)src.ModifiedOn).ToString(CultureInfo.InvariantCulture)));
        }
    }
}
