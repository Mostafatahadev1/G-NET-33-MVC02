using Gym.Presentation.Data.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gym.Presentation.Controllers
{
    public class PlansController : Controller
    {
        public GymDbContext Context =new GymDbContext();
        public async Task<IActionResult>Index()
        {
            var Plans = await Context.Plans.ToListAsync();
            return View(Plans);
        }

        public async Task<IActionResult>Details(int id)
        {

            if (id <= 0)
            {
                return NotFound();
            }
            var plan = await Context.Plans.FirstOrDefaultAsync(p => p.Id == id);
            if (plan == null)
            {
                return RedirectToAction(nameof(Index)); // Return 302       Location         
              
            }
            return View(plan);//views / plans/details.cshtml
        }

    }
}
