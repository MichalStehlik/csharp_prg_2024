using cs04_fluentEfc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs04_fluentEfc.Data
{
    internal class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Record> Records { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Tasks01;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Guid user1 = Guid.NewGuid();
            Guid user2 = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(
                new User { UserId = user1, Firstname = "John", Lastname = "Doe" },
                new User { UserId = user2, Firstname = "Jane", Lastname = "Doe" },
                new User { UserId = Guid.NewGuid(), Firstname = "Alice", Lastname = "Smith" },
                new User { UserId = Guid.NewGuid(), Firstname = "Bob", Lastname = "Smith" }
            );
            modelBuilder.Entity<Record>(option =>
            {
                option.HasOne(r => r.Creator)
                    .WithMany(u => u.CreatedRecords)
                    .HasForeignKey(r => r.CreatorId)
                    .OnDelete(DeleteBehavior.Restrict);
                option.HasOne(r => r.User)
                    .WithMany(u => u.AssignedRecords)
                    .HasForeignKey(r => r.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
                option.HasData(
                    new Record { RecordId = 1, Description = "Task 1", CreatorId = user1, UserId = user2 },
                    new Record { RecordId = 2, Description = "Task 2", CreatorId = user2, UserId = user1 }
                );
            });
        }
    }
}
