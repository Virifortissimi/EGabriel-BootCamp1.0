using HttpRequest;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
void ConfigureServices(IServiceCollection services)
{
    services.AddHttpClient<IWeatherService, weatherServices>(c => 
    { c.BaseAddress = new Uri("http://api.weatherapi.com/v1/current.json");
    });

    services.AddControllers();
}

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

app.UseAuthorization();

app.MapControllers();

app.Run();
