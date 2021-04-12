using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using VeXe.Common.Exceptions;
using VeXe.Domain;
using VeXe.DTO;
using VeXe.Persistence;

namespace VeXe.Service.Impl
{
    public class ExampleService : IExampleService
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ExampleService(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<AbcDto>> GetList()
        {
            var data = await _context.Abcs
                .ProjectTo<AbcDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
            return data;
        }

        public async Task<AbcDto> GetOne(int id)
        {
            var entity = await _context.Abcs.FindAsync(id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Abc), id);
            }

            return _mapper.Map<AbcDto>(entity);
        }
    }
}