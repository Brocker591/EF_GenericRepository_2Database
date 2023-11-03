using EF_GenericRepository_2Database_repository.Models;
using Microsoft.EntityFrameworkCore;


namespace EF_GenericRepository_2Database_repository
{
    public static class CreateSqlModelsExtentions
    {
        public static void InitializeSqlModels(this ModelBuilder modelBuilder, MyDbContext myDbContext)
        {

            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("authors");

                entity.HasKey(e => e.Id);

                entity.HasMany(author => author.Books)
                .WithOne(book => book.Author)
                .HasForeignKey(book => book.AuthorId)
                .HasConstraintName("FK_authors_books")
                .IsRequired();
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("books");
                entity.HasKey(e => e.Id);

                entity.HasOne(book => book.Author)
                .WithMany(author => author.Books)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("FK_authors_books");
            });

            if (myDbContext.Database.IsSqlServer())
                Console.WriteLine("I am MSSql");

            if (myDbContext.Database.IsNpgsql())
                Console.WriteLine("I am PostgreSQL");
        }
    }
}
