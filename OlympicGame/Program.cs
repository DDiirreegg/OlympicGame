using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OlympicGame;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("PSQL"));
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapGet("sport", (ApplicationDbContext context) => context.sport.ToList());
app.MapGet("event", (ApplicationDbContext context) => context.Event.Include(e => e.sport).ToList());
app.MapGet("games", (ApplicationDbContext context) => context.games.ToList());

app.MapControllers();

app.Run();