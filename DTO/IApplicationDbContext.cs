using System.Threading;
using System.Threading.Tasks;
using VeXe.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace VeXe.DTO
{
    public interface IApplicationDbContext
    {
        DbSet<Abc> Abcs { get; set; }
        
        DatabaseFacade Database { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
