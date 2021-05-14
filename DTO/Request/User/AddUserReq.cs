using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Newtonsoft.Json;
using BC = BCrypt.Net.BCrypt;
using VeXe.DTO;
using VeXe.Persistence;

namespace VeXe.Dto.Request.User
{
    public class AddUserReq : IRequest<UserDto>
    {

        [JsonRequired]
        [JsonProperty(PropertyName = "email")] public string Email { get; set; }

        [JsonRequired]
        [JsonProperty(PropertyName = "password")] public string Password { get; set; }

        [JsonRequired]
        [JsonProperty(PropertyName = "full_name")] public string FullName { get; set; }

        [JsonRequired]
        public string Mobile { get; set; }
        public int Age { get; set; }
        public string Note { get; set; }
        [JsonProperty(PropertyName = "group_id")] public int GroupId { get; set; }
        public string BirthDate { get; set; }
        public int Status { get; set; }


        public class AddUserHandler : IRequestHandler<AddUserReq, UserDto>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public AddUserHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<UserDto> Handle(AddUserReq request, CancellationToken cancellationToken)
            {
                var domain = new Domain.User()
                {
                    Email = request.Email,
                    Status = request.Status,
                    FullName = request.FullName,
                    GroupId = request.GroupId,
                    Password = BC.HashPassword(request.Password),
                    Age = request.Age,
                    BirthDate = Convert.ToDateTime(request.BirthDate),
                    Mobile = request.Mobile,
                    Note = request.Note,
                };

                await _context.Users.AddAsync(domain);
                await _context.SaveChangesAsync(cancellationToken);

                return _mapper.Map<UserDto>(domain);
            }
        }
    }
}