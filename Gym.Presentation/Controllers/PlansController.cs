using Gym.DataAccess.Repositries;
using Microsoft.AspNetCore.Mvc;

namespace Gym.Presentation.Controllers
{
    public class PlansController(IPlanRepository planRepo) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var plans = await planRepo.GetAllAsync();
            return View(plans);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }

            var plan = await planRepo.GetByIdAsync(id);

            if (plan == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(plan);
        }


    }
}