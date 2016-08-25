using DungeonHub.Models;
using DungeonHub.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace DungeonHub.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var upcomingSessions = _context.Sessions
                .Include(s => s.GM)
                .Include(s => s.GameSystem)
                .Where(s => s.DateTime > DateTime.Now);

            var viewModel = new SessionsViewModel
            {
                UpcomingSessions = upcomingSessions,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Upcoming Sessions"
            };
            return View("Sessions", viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}