using Microsoft.EntityFrameworkCore;
using WebAPIAFFS.DAL.Entity;

namespace WebAPIAFFS.DAL.DBContext1
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; }

        public virtual DbSet<District> Districts { get; set; }

        public virtual DbSet<FinancialYear> FinancialYears { get; set; }

        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectNature> ProjectNatures { get; set; }

        public virtual DbSet<ProjectType> PrrojectTypes { get; set; }

        public virtual DbSet<Site> Sites { get; set; }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Department>()            
            .Property(e => e.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<District>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<FinancialYear>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Department).WithMany(p => p.Projects);

                entity.HasOne(d => d.FinancialYear).WithMany(p => p.Projects);

                entity.HasOne(d => d.ProjectNature).WithMany(p => p.Projects);

                entity.HasOne(d => d.ProjectType).WithMany(p => p.Projects);
            });

            modelBuilder.Entity<ProjectNature>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<ProjectType>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.ProjectNature).WithMany(p => p.ProjectTypes);
            });

            modelBuilder.Entity<Site>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.District).WithMany(p => p.Sites);

                entity.HasOne(d => d.Project).WithMany(p => p.Sites);
            });

      
        }

        

    }
}
