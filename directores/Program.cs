//05-05 nota#5
using directores;
using directores.DBContexts;
using directores.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//IDD#2
builder.Services.AddSingleton<DirectoresData>();
builder.Services.AddDbContext<DirectoresContext>(dbContextOptions => dbContextOptions.UseSqlite(
        builder.Configuration["ConnectionStrings:DirectoresDBConnectionString"])
);
builder.Services.AddScoped<IDirectoresRepository, DirectoresRepository>();

//esto lo agrego para usar AutoMapper, el AddAutoMapper. Esto le dice dónde buscar los profiles que vamos a crear
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());




var app = builder.Build();

// Configure the HTTP request pipeline. esto va a configurar la pipeline, donde se van a canalizar las peticiones)
if (app.Environment.IsDevelopment())
{
    //clase 05/05 - nota #2
    //estas dos líneas son para usar swagger, que nos genera el JSON para que podamos ver
    //esto genera un JSON
    app.UseSwagger();
    //esto genera la pagina que entiende ese JSON - video 05-05
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
