using Azure;
using EF_GenericRepository_2Database_repository.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_GenericRepository_2Database_repository
{
    public static class CreateSqlDataExtentions
    {
        public static void InitializeSqlData(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "A database primer", Publication = 2000, AuthorId = 1 },
                new Book { Id = 2, Title = "Building a datawarehouse", Publication = 2001, AuthorId = 1 },
                new Book { Id = 3, Title = "Teach yourself SQL", Publication = 2005, AuthorId = 1 },
                new Book { Id = 4, Title = "101 exotic recipes", Publication = 2000, AuthorId = 2 },
                new Book { Id = 5, Title = "Visiting europe", Publication = 2000, AuthorId = 4 }
            );

            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, Firstname = "John", Lastname = "Henry", Age = 40},
                new Author { Id = 2, Firstname = "Adam", Lastname = "Smith", Age = 40 },
                new Author { Id = 3, Firstname = "Mary", Lastname = "Johnson", Age = 40 },
                new Author { Id = 4, Firstname = "Harry", Lastname = "Bailey", Age = 40 }
           );


        }
    }
}
