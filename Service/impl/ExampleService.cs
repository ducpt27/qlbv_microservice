using System;
using System.Threading.Tasks;
using MySqlConnector;
using VeXe.Domain;
using VeXe.DTO;
using VeXe.Exceptions;

namespace VeXe.Service.Impl
{
    public class ExampleService : IExampleService
    {
        
        private readonly IApplicationDbContext _context;

        public ExampleService(IApplicationDbContext context)
        {
            _context = context;
        }

        public string GetAbc(string xyz)
        {
            return "Hello " + xyz;
        }

        public async Task<string> GetInDbTest(int id)
        {
            var entity = await _context.Abcs.FindAsync(id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Abc), id);
            }

            return entity.Name;
        }
    }
}