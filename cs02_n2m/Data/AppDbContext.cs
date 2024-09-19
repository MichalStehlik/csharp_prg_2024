using cs02_n2m.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs02_n2m.Data
{
    internal class AppDbContext : DbContext
    {
        public AppDbContext() : base()
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Boox01;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Author>().ToTable("Authors"); // This is optional
            modelBuilder.Entity<Author>(opt =>
            {
                opt.HasKey(a => a.AuthorId);
                opt.Property(a => a.Firstname).IsRequired();
                opt.Property(a => a.Lastname).IsRequired();
                opt.HasMany(a => a.Books).WithMany(b => b.Authors).UsingEntity<BookAuthor>();
                opt.HasData(
                    new Author { AuthorId = 1, Firstname = "Charles", Lastname = "Baudelaire" },
                    new Author { AuthorId = 2, Firstname = "John", Lastname = "Steinbeck" }           
                );
            });
            modelBuilder.Entity<Book>().HasData(
                new Book { BookId = 1, Title = "Květy zla" },
                new Book { BookId = 2, Title = "Hrozny hněvu" },
                new Book { BookId = 3, Title = "Na východ od ráje" }
            );
            modelBuilder.Entity<BookAuthor>(opt =>
            {
                opt.HasKey(ba => new { ba.BookId, ba.AuthorId });
                opt.HasData(
                    new BookAuthor { AuthorId = 1, BookId = 1 },
                    new BookAuthor { AuthorId = 2, BookId = 2 },
                    new BookAuthor { AuthorId = 2, BookId = 3 }
                    );
            }
            );
        }
    }
}
