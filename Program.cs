using System.Text.Json;
using System.Text.Json.Serialization;
using sistemaDeTarefasT2m.Infraestrutura.Data;
using sistemaDeTarefasT2m.IRepository;
using sistemaDeTarefasT2m.IService;
using sistemaDeTarefasT2m.Repository;
using sistemaDeTarefasT2m.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();



var Configuration = builder.Configuration;
builder.Services.AddScoped<IUserService, UserService>();   

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<ITarefasService, TarefaService>();

builder.Services.AddScoped<ITarefasRepository, TarefaRepository>();

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("PostgreSQLConnection");

builder.Services.AddScoped<PostgresConnection>(provider =>
{   
    return new PostgresConnection(connectionString);
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
