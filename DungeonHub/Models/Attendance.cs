using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DungeonHub.Models
{
    public class Attendance
    {
        public Session Session { get; set; }
        public ApplicationUser Player { get; set; }

        [Key, Column(Order = 1)]
        public int SessionId { get; set; }

        [Key, Column(Order = 2)]
        public string PlayerId { get; set; }
    }
}