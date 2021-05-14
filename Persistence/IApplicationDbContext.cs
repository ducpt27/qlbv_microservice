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
        DbSet<DriveSchedule> DriveSchedules { get; set; }
        DbSet<Province> Provinces { get; set; }
        DbSet<Ward> Wards { get; set; }

        DbSet<DrivePrice> DrivePrices { get; set; }
        DbSet<DrivePoint> DrivePoints { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderItem> OrderItems { get; set; }
        DatabaseFacade Database { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
