﻿// <auto-generated />
using EF_GenericRepository_2Database_repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EF_GenericRepository_2Database.MSSql.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EF_GenericRepository_2Database_repository.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("authors", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 40,
                            Firstname = "John",
                            Lastname = "Henry"
                        },
                        new
                        {
                            Id = 2,
                            Age = 40,
                            Firstname = "Adam",
                            Lastname = "Smith"
                        },
                        new
                        {
                            Id = 3,
                            Age = 40,
                            Firstname = "Mary",
                            Lastname = "Johnson"
                        },
                        new
                        {
                            Id = 4,
                            Age = 40,
                            Firstname = "Harry",
                            Lastname = "Bailey"
                        });
                });

            modelBuilder.Entity("EF_GenericRepository_2Database_repository.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("Publication")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("books", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            Publication = 2000,
                            Title = "A database primer"
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 1,
                            Publication = 2001,
                            Title = "Building a datawarehouse"
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 1,
                            Publication = 2005,
                            Title = "Teach yourself SQL"
                        },
                        new
                        {
                            Id = 4,
                            AuthorId = 2,
                            Publication = 2000,
                            Title = "101 exotic recipes"
                        },
                        new
                        {
                            Id = 5,
                            AuthorId = 4,
                            Publication = 2000,
                            Title = "Visiting europe"
                        });
                });

            modelBuilder.Entity("EF_GenericRepository_2Database_repository.Models.Book", b =>
                {
                    b.HasOne("EF_GenericRepository_2Database_repository.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_authors_books");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("EF_GenericRepository_2Database_repository.Models.Author", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
