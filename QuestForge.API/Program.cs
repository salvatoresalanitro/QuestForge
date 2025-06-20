using Microsoft.EntityFrameworkCore;
using QuestForge.API.Mappings;
using QuestForge.Core.RepositoryInterfaces;
using QuestForge.Infrastructure.Data;
using QuestForge.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<QuestForgeContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("QuestForgeConnection")));

builder.Services.AddAutoMapper(typeof(CharacterProfile));
builder.Services.AddScoped<ICharacterRepository, CharacterRepository>();

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
