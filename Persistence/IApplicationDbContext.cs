using System.Threading;
using System.Threading.Tasks;
using VeXe.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace VeXe.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<Abc> Abcs { get; set; }
        
        DbSet<Route> Route { get; set; }
        
        DbSet<Point> Points { get; set; }
        DbSet<Car> Cars { get; set; }
        DatabaseFacade Database { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
