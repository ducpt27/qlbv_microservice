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

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ICurrentUserService currentUserService, IDateTime dateTime)
            : base(options)
        {
            _currentUserService = currentUserService;
            _dateTime = dateTime;
        }
        public DbSet<Abc> Abcs { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Point> Points { get; set; }
        public DbSet<RoutePoint> RoutePoints { get; set; }

        public DbSet<Car> Cars { get; set; }


    
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.Username;
                        entry.Entity.CreatedOn = _dateTime.Now;
                        break;
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
                    
            modelBuilder.Entity<RoutePoint>().HasKey(sc => new { sc.PointId, sc.RouteId });

            modelBuilder.Entity<RoutePoint>()
                .HasOne<Route>(sc => sc.Route)
                .WithMany(s => s.RoutePoints)
                .HasForeignKey(sc => sc.RouteId);


            modelBuilder.Entity<RoutePoint>()
                .HasOne<Point>(sc => sc.Point)
                .WithMany(s => s.RoutePoints)
                .HasForeignKey(sc => sc.PointId);
        }
    }
}