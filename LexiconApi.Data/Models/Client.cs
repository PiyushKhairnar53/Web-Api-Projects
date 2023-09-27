using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconApi.Data.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        [Required]
        public int Age { get; set; }
        public string? Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public ICollection<Matter> Matters { get; set; }
    }
}
