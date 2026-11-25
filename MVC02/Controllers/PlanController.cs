using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC02.Contexts;

namespace MVC02.Controllers
{
    public class PlanController : Controller
    {
        GymDbContext DbContext = new GymDbContext();
        public async Task<IActionResult> Index()
        {
            var plans = await DbContext.Plans.ToListAsync();
            return View(plans);
        }
        public IActionResult IndexTest()
        {
            return View();

            // return View ("Test");

            // return View ("Test", new Member(){Id =1});

            // return View ( new Member() {Id =1} );
        }
    }
}
