using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace FootballersDirectory.Models
{
    [Index(nameof(GenderName), IsUnique = true)]
    public class GenderEntity
    {
        [Key]
        public int GenderId { get; set; }
        public string GenderName { get; set; }
        public Collection<FootballerEntity> Footballers { get; set; }
    }
}
