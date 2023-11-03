using EF_GenericRepository_2Database_repository.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_GenericRepository_2Database_repository;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.InitializeSqlModels(this);
        modelBuilder.InitializeSqlData();


    }

}
