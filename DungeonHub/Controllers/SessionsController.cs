using DungeonHub.Models;
using DungeonHub.ViewModels;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace DungeonHub.Controllers
{
    public class SessionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SessionsController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Playing()
        {
            var userId = User.Identity.GetUserId();
            var sessions = _context.Players
                .Where(p => p.PlayerId == userId)
                .Select(p => p.Session)
                .Include(g => g.GM)
                .Include(g => g.GameSystem)
                .ToList();

            var viewModel = new SessionsViewModel()
            {
                UpcomingSessions = sessions,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Sessions I'm Attending"
            };

            return View("Sessions", viewModel);
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new SessionFormViewModel
            {
                GameSystems = _context.GameSystems.ToList()
            };

            return View(viewModel);
        }

        [Authorize, HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(SessionFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.GameSystems = _context.GameSystems.ToList();
                return View("Create", viewModel);
                
            }
            var session = new Session
            {
                GMId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                GameSystemId = viewModel.GameSystem,
                Location = viewModel.Location
            };

            _context.Sessions.Add(session);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}