using Gym.DataAccess.Repositries;
using Microsoft.AspNetCore.Mvc;

namespace Gym.Presentation.Controllers
{
    public class PlansController : Controller
    {
        public IPlanRepository PlanRepo = new PlanRepository();

        public async Task<IActionResult> Index()
        {
            var plans = await PlanRepo.GetAllAsync();
            return View(plans);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }

            var plan = await PlanRepo .GetByIdAsync(id);

            if (plan == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(plan);
        }


    }
}