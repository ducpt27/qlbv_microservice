using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VeXe.Common;
using VeXe.Domain;
using VeXe.DTO;
using VeXe.Service;

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
        public DbSet<Route> Route { get; set; }
        public DbSet<Point> Points { get; set; }

        public DbSet<Car> Cars { get; set; }


    
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.UserId.ToString();
                        entry.Entity.CreatedOn = _dateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedBy = _currentUserService.UserId.ToString();
                        entry.Entity.ModifiedOn = _dateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            modelBuilder.Entity<Route>()
                .HasMany<Point>(r => r.Points)
                .WithMany(s => s.Routes)
                .
        }
        
        
        
    }
}


