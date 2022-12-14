using cassadraTestAPI.Config;
using Cassandra.Mapping;

var builder = WebApplication.CreateBuilder(args);

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
MappingConfiguration.Global.Define<CassandranMappings>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
