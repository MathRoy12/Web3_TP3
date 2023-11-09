using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Jmepromeneavecmesvalises_API.Data;
using Jmepromeneavecmesvalises_API.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Jmepromeneavecmesvalises_APIContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Jmepromeneavecmesvalises_APIContext") ??
                         throw new InvalidOperationException(
                             "Connection string 'Jmepromeneavecmesvalises_APIContext' not found."));
    options.UseLazyLoadingProxies();
});

builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<Jmepromeneavecmesvalises_APIContext>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();