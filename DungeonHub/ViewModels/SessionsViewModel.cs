using DungeonHub.Models;
using System.Collections.Generic;

namespace DungeonHub.ViewModels
{
    public class SessionsViewModel
    {
        public IEnumerable<Session> UpcomingSessions { get; set; }
        public bool ShowActions { get; set; }
        public string Heading { get; set; }
    }
}