using Microsoft.EntityFrameworkCore;
using TODO.API.Data;
using TODO.API.Data.Interfaces;
using TODO.API.Data.Repository;
using TODO.API.Manager;
using TODO.API.Models.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Todo API", Version = "v1" });
});
builder.Services.AddCors();
builder.Services.AddDbContext<DataContext>(x => x.UseSqlite("Data Source=TodoApp.db"));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Scoped Services
builder.Services.AddScoped<ITodoRepository, TodoRepository>();
builder.Services.AddScoped<INotesRepository, NotesRepository>();

//Transient Services
builder.Services.AddTransient<NotesManager>();


var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
// Enable middleware to serve generated Swagger as a JSON endpoint.
app.UseSwagger();
// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
// specifying the Swagger JSON endpoint.
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});
// }

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateAsyncScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<DataContext>();
    var Seeder = new Seed(dataContext);
    Seeder.SeedData();
}


app.Run();


