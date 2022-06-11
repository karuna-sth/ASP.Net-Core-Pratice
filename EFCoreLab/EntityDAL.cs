using EFCoreLab.Entity;
using Microsoft.EntityFrameworkCore;

namespace EFCoreLab
{
    public class EntityDAL : DbContext
    {
        public EntityDAL(DbContextOptions<EntityDAL> options) : base(options)
        {
            
        }
        public DbSet<Employee>? Employee { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                
                entity.Property(e => e.EmployeeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeAddress)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

            });
        }
    }
}
