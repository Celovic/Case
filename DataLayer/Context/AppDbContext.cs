using DataLayer.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<FormList> Forms { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<FormField> FormFields { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Form ve Field arasındaki birden çoğa ilişkiyi tanımlıyoruz.
            modelBuilder.Entity<FormList>()
                .HasMany(f => f.FormFields)
                .WithOne(f => f.FormList)
                .HasForeignKey(f => f.FormId);
        }
    }


}
