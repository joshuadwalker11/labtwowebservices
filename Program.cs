using Microsoft.EntityFrameworkCore;
using TodoApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddXmlSerializerFormatters();

// integrating cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("allowall", builder => // naming Cors allowall
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); // bunch of stuff to add to it
    });
});
// add ability to output xml


//builder.Services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("todo"));

builder.Services.AddDbContextFactory<TodoContext>(
    options => options.UseSqlite(builder.Configuration.GetConnectionString("TodoConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

app.UseCors("allowall"); // instituting cors (named "allowall") in app

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();
app.Run();
