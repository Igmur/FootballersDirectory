using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace FootballersDirectory.Models
{
    [Index(nameof(CommandName), IsUnique = true)]
    public class CommandEntity
    {
        [Key]
        public int CommandId { get; set; }
        public string CommandName { get; set; }
        public Collection<FootballerEntity> Footballers { get; set; }
    }
}
