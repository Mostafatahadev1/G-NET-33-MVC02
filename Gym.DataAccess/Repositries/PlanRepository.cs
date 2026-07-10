using Gym.DataAccess.Models;
using Gym.Presentation.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.DataAccess.Repositries
{
    public class PlanRepository : IPlanRepository
    {
        public GymDbContext dbContext = new GymDbContext(); 
        public void Add(Plan plan)
         => dbContext.Add(plan);

        public void Delete(Plan plan)
         => dbContext.Remove(plan);

        public async Task<IEnumerable<Plan>> GetAllAsync()
         => await dbContext.Plans.ToListAsync();


        public async Task<Plan?> GetByIdAsync(int id)
           => await dbContext.Plans.FirstOrDefaultAsync(p => p.Id == id);

        public async Task<int> SaveChangesAsync()
        => await dbContext.SaveChangesAsync();

        public void Update(Plan plan)
        => dbContext.Update(plan);



    }
}
