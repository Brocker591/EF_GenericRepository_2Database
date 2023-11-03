using EF_GenericRepository_2Database.Dtos;
using EF_GenericRepository_2Database_repository;
using EF_GenericRepository_2Database_repository.Models;
using EF_GenericRepository_2Database_repository.Repositories;
using Microsoft.EntityFrameworkCore;
using static EF_GenericRepository_2Database.Provider;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IRepository<Author>, RepositoryAsync<Author> >();
builder.Services.AddScoped<IRepository<Book>, RepositoryAsync<Book>>();






var provider = builder.Configuration.GetSection("DatabaseProvider").Value;

builder.Services.AddDbContext<MyDbContext>(options =>
{
    if(provider == Postgres.Name)
    {
        options.UseNpgsql(
            builder.Configuration.GetConnectionString(Postgres.Name)!,
            x => x.MigrationsAssembly(Postgres.Assembly)
        );
    }


    if (provider == MSSql.Name)
    {
        options.UseSqlServer(
            builder.Configuration.GetConnectionString(MSSql.Name)!,
            x => x.MigrationsAssembly(MSSql.Assembly)
        );
    }
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();



using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<MyDbContext>();

await dbContext.Database.MigrateAsync();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
