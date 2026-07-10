using Gym.Presentation.Data.Contexts;
using Gym.Presentation.Presentation.Data.Seeder;

namespace Gym.Presentation.Data.Seeder
{
    public static class DatabaseSeeder
    {
        public static async Task SeedAllAsync(GymDbContext dbContext)
        {
            await PlanSeeder.SeedAsync(dbContext); 
        }
    }
}
