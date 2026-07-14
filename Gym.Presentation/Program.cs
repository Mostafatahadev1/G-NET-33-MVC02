using Gym.DataAccess.Repositries;
using Gym.Presentation.Data.Contexts;
using Gym.Presentation.Data.Seeder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<GymDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IPlanRepository, PlanRepository>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

await using var Scope = app.Services.CreateAsyncScope();


var dbContext = Scope.ServiceProvider.GetRequiredService<GymDbContext>();

await DatabaseSeeder.SeedAllAsync(dbContext);


app.Run();

