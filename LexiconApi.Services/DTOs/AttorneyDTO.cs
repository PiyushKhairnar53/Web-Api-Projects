using LexiconApi.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LexiconApi.Services.DTOs
{
    public class AttorneyDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public int Age { get; set; }

        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string Phone { get; set; } = null!;
        [Required]
        public int Rate { get; set; }
        [Required]
        public int JurisdictionId { get; set; }    
       
    }
}
