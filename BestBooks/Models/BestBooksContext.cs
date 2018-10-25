using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BestBooks.Models
{
    public class BestBooksContext : DbContext

    {
        public BestBooksContext() : base("BestBooksDBConnectionString")
        {
            Database.SetInitializer<BestBooksContext>(new CreateDatabaseIfNotExists<BestBooksContext>());
            
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
              modelBuilder.Entity<Book>()
                .HasMany(m => m.AuthorId)
                .WithMany(g => g.Books)
                .Map(ca =>
                {
                    ca.MapLeftKey("BookId");
                    ca.MapRightKey("AuthorId");
                    ca.ToTable("BookAuthor");
                }
                );
            modelBuilder.Entity<Book>()
                .HasMany(m => m.GenreId)
                .WithMany(a => a.Books)
                .Map(ca =>
                {
                    ca.MapLeftKey("BookId");
                    ca.MapRightKey("GenreId");
                    ca.ToTable("BookGenres");
                });

            modelBuilder.Entity<Publisher>().HasMany(m => m.Books).WithRequired(n => n.Publisher);
               
            
        }
    }
}