using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballersDirectory.Models
{
    public class FootballerEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        [ForeignKey("GenderId")]
        public GenderEntity Gender { get; set; }

        public DateTime BirthDate { get; set; }

        [ForeignKey("CommandId")]
        public CommandEntity Command { get; set; }

        public string Country { get; set; }
    }
}
