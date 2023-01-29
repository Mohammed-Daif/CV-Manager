using CV_Manager.DB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CV_Manager.DB
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<CV> cVs { get; set; }
        public DbSet<PersonalInformation> personalInfo { get; set; }
        public DbSet<ExperienceInformation> experienceInfoList { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PersonalInformation>().HasOne<CV>(p => p.CandidateCV).WithOne(c => c.PersonalInformation).HasForeignKey<CV>(c => c.PersonalInformationId);
            modelBuilder.Entity<CV>().HasKey(c => c.Id);
            modelBuilder.Entity<CV>().HasMany(c => c.ExperienceInfoList).WithOne(p => p.CandidateCV).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<CV>().HasOne(c => c.PersonalInformation).WithOne(p => p.CandidateCV).OnDelete(DeleteBehavior.Cascade);
        }
        public override int SaveChanges()
        {
            UpdateBaseEntity();
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateBaseEntity();
            return base.SaveChangesAsync(cancellationToken);
        }
        private void UpdateBaseEntity()
        {
            var modifiedEntities = ChangeTracker.Entries().Where(x => x.Entity is BaseModel && (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (var entity in modifiedEntities)
            {
                if (entity.State == EntityState.Added)
                {
                    (entity.Entity as BaseModel).CreatedAt = DateTime.UtcNow;
                }
                else
                {
                    (entity.Entity as BaseModel).UpdatedAt = DateTime.UtcNow;
                }
            }
        }
    }
}
