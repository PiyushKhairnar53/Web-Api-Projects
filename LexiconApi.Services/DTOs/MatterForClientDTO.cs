using LexiconApi.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconApi.Services.DTOs
{
    public class MatterForClientDTO
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public int IsActive { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }

        [Required]
        public string JurisdictionArea { get; set; }
        public string ClientName { get; set; }

        [Required]
        public string BillingAttorneyName { get; set; }

        [Required]
        public string ResponsibleAttorneyeName { get; set; }

    }
}
