using DungeonHub.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DungeonHub.ViewModels
{
    public class SessionFormViewModel
    {
        [Required]
        public string Location { get; set; }

        [Required, FutureDate]
        public string Date { get; set; }

        [Required]
        [ValidTime]
        public string Time { get; set; }

        [Required]
        public byte GameSystem { get; set; }

        public IEnumerable<GameSystem> GameSystems { get; set; }

        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }
    }
}