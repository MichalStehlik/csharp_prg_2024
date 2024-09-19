using cs03_sqlite.Models;
using Microsoft.EntityFrameworkCore;

namespace cs03_sqlite.Data
{
    internal class AppDbContext : DbContext
    {
        public AppDbContext() : base()
        {
        }

        public DbSet<Human> Humans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("Data Source=app.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Human>()
                .HasMany(h => h.CreatedTasks)
                .WithOne(t => t.From)
                .HasForeignKey(t => t.FromId);
            modelBuilder.Entity<Human>()
                .HasMany(h => h.AssignedTasks)
                .WithOne(t => t.To)
                .HasForeignKey(t => t.ToId);
            modelBuilder.Entity<Human>().HasData(
                new Human { HumanId = 1, Firstname = "John", Lastname = "Doe" },
                new Human { HumanId = 2, Firstname = "Jane", Lastname = "Doe" }
            );
        }
    }
}
