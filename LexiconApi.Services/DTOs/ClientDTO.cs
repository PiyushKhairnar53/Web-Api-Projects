using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconApi.Services.DTOs
{
    public class ClientDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public string? Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
