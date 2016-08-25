using DungeonHub.Dtos;
using DungeonHub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace DungeonHub.Controllers
{
    [Authorize]
    public class PlayersController : ApiController
    {
        private ApplicationDbContext _context;

        public PlayersController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Play(AttendanceDto dto)
        {
            var userId = User.Identity.GetUserId();

            if (_context.Players.Any(a => a.PlayerId == userId && a.SessionId == dto.SessionId))
                return BadRequest("The attendance already exists.");

            var attendance = new Attendance
            {
                SessionId = dto.SessionId,
                PlayerId = userId
            };

            _context.Players.Add(attendance);
            _context.SaveChanges();

            return Ok();
        }
    }
}
