using MySql.EntityFrameworkCore.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddControllersWithViews()
    .AddNewtonsoftJson();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<WeatherStationDbContext>(options =>
{
    options.UseMySQL(connectionString, (Action<MySQLDbContextOptionsBuilder>)null);
});

builder.Services.AddScoped<IReportsRepository, ReportsRepository>();

var influxConfiguration = builder.Configuration.GetSection("Influx").Get<InfluxConfiguration>();

Metrics.Collector = new CollectorConfiguration()
    //.Batch.AtInterval(TimeSpan.FromSeconds(2))
    .WriteTo.InfluxDB(influxConfiguration.ServerUrl, influxConfiguration.Database, influxConfiguration.Username, influxConfiguration.Password)
    .CreateCollector();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();