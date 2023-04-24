using LexiconApi.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconApi.Services.DTOs
{
    public class JurisdictionDTO
    {
        public int Id { get; set; }
        [Required]
        public string Area { get; set; }
    }
}
