using Gym.Presentation.Data.Contexts;
using Gym.Presentation.Data.Seeder;
using Microsoft.EntityFrameworkCore;
using Gym.DataAccess.Repositries;
using Gym.DataAccess.Repositries; // ??? ??? ??? ?????? Repositories

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<GymDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Add services to the container.
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

