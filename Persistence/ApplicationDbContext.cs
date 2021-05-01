using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VeXe.Common;
using VeXe.Domain;
using VeXe.DTO;
using VeXe.Service;
using System.Data;

namespace VeXe.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
            ICurrentUserService currentUserService, IDateTime dateTime)
            : base(options)
        {
            _currentUserService = currentUserService;
            _dateTime = dateTime;
        }

        public DbSet<Route> Routes { get; set; }
        public DbSet<Chair> Chairs { get; set; }
        public DbSet<Point> Points { get; set; }
        public DbSet<RoutePoint> RoutePoints { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<DriveSchedule> DriveSchedules { get; set; }
        public DbSet<Province> Provinces { get; set; }
        
        public DbSet<DrivePrice> DrivePrices { get; set; }
        public DbSet<DrivePoint> DrivePoints { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                var now = _dateTime.Now;
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.Username;
                        entry.Entity.ModifiedBy = _currentUserService.Username;
                        entry.Entity.CreatedOn = now;
                        entry.Entity.ModifiedOn = now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedBy = _currentUserService.Username;
                        entry.Entity.ModifiedOn = now;
                        break;
                }
            }

            foreach (var entry in ChangeTracker.Entries<ModifiedEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Entity.ModifiedBy = _currentUserService.Username;
                        entry.Entity.ModifiedOn = _dateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            modelBuilder.Entity<RoutePoint>().HasKey(sc => new {sc.PointId, sc.RouteId});
            modelBuilder.Entity<RoutePoint>()
                .HasOne<Route>(sc => sc.Route)
                .WithMany(s => s.RoutePoints)
                .HasForeignKey(sc => sc.RouteId);
            modelBuilder.Entity<RoutePoint>()
                .HasOne<Point>(sc => sc.Point)
                .WithMany(s => s.RoutePoints)
                .HasForeignKey(sc => sc.PointId);

            modelBuilder.Entity<Chair>()
                .HasOne(p => p.Car);
            
            modelBuilder.Entity<Car>()
                .HasMany(s => s.Chairs);
            modelBuilder.Entity<Car>()
                .HasMany(s => s.DriveSchedules);
            
            
            modelBuilder.Entity<Province>()
                .HasMany(s => s.Districts);
            modelBuilder.Entity<District>()
                .HasMany(s => s.Wards);
            
            modelBuilder.Entity<DriveSchedule>()
                .HasMany(s => s.OrderItems);
            modelBuilder.Entity<DriveSchedule>()
                .HasMany(s => s.DrivePrices);
            modelBuilder.Entity<DriveSchedule>()
                .HasMany(s => s.DrivePoints);
            modelBuilder.Entity<DriveSchedule>()
                .HasOne(s => s.Car);
            
            modelBuilder.Entity<Order>()
                .HasMany(s => s.OrderItems);
            
            modelBuilder.Entity<OrderItem>()
                .HasOne(s => s.DriveSchedule);
            modelBuilder.Entity<OrderItem>()
                .HasOne(s => s.Chair);
        }
    }
}