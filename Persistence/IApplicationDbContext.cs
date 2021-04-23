using System.Threading;
using System.Threading.Tasks;
using VeXe.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace VeXe.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<Route> Routes { get; set; }
        DbSet<Chair> Chairs { get; set; }
        DbSet<Point> Points { get; set; }
        DbSet<RoutePoint> RoutePoints { get; set; }
        DbSet<Car> Cars { get; set; }
        DatabaseFacade Database { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
