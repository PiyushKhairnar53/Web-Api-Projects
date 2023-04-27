using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconApi.Services.DTOs
{
    public class MatterByClientDTO
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = null!;

        public string? Category { get; set; }

        [Required]
        public string JurisdictionArea { get; set; }
        public int ClientId { get; set; }

        public string ClientName { get; set; }

        [Required]
        public string BillingAttorneyName { get; set; }

        [Required]
        public string ResponsibleAttorneyeName { get; set; }
    }
}
