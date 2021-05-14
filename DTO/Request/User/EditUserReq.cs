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
using VeXe.Persistence;

namespace VeXe.DTO.Request.User
{
    public class EditUserReq : IRequest<UserDto>
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonRequired]
        [JsonProperty(PropertyName = "email")] public string Email { get; set; }


        [JsonRequired]
        [JsonProperty(PropertyName = "full_name")] public string FullName { get; set; }

        [JsonRequired]
        public string Mobile { get; set; }
        public int Age { get; set; }
        public string Note { get; set; }
        [JsonProperty(PropertyName = "group_id")] public int GroupId { get; set; }
        public string BirthDate { get; set; }
        public int Status { get; set; }

        public class EditUserHandler : IRequestHandler<EditUserReq, UserDto>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public EditUserHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }


            public async Task<UserDto> Handle(EditUserReq request, CancellationToken cancellationToken)
            {
                var entity = await _context.Users
                    .FindAsync(request.Id);
                if (entity == null)
                {
                    throw new NotFoundException(nameof(User), request.Id);
                }

                entity.Email = request.Email;
                entity.Status = request.Status;
                entity.Note = request.Note;
                entity.FullName = request.FullName;
                entity.GroupId = request.GroupId;
                entity.Mobile = request.Mobile;
                entity.Age = request.Age;
                entity.BirthDate = Convert.ToDateTime(request.BirthDate);

                await _context.SaveChangesAsync(cancellationToken);

                return await _context.Users
                    .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                    .Where(e => e.Id == request.Id)
                    .FirstAsync();
            }
        }
    }
}