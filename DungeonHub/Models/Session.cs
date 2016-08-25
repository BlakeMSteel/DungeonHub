using System;
using System.ComponentModel.DataAnnotations;

namespace DungeonHub.Models
{
    public class Session
    {
        public int Id { get; set; }

        public ApplicationUser GM { get; set; }

        [Required]
        public string GMId { get; set; }

        public DateTime DateTime { get; set; }

        [Required, StringLength(255)]
        public string Location { get; set; }

        public GameSystem GameSystem { get; set; }

        [Required]
        public byte GameSystemId { get; set; }
    }
}