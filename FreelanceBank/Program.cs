using FreelanceBank.Abstractions.Repositories;
using FreelanceBank.Abstractions.Services;
using FreelanceBank.Database.Context;
using FreelanceBank.Database.Repository;
using FreelanceBank.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<FreelanceBankDbContext>();
builder.Services.AddTransient<IUserWalletRepository, UserWalletRepository>();
builder.Services.AddTransient<IUserWalletService, UserWalletService>();

var app = builder.Build();

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
