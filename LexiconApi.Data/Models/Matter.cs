using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconApi.Data.Models
{
    public class Matter
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int IsActive { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }

        [Required]
        public int JurisdictionId { get; set; }
        public Jurisdiction Jurisdiction { get; set; } = null!;

        [Required]
        public int ClientId { get; set; }
        public Client Client { get; set; }

        [Required]
        public int BillingAttorneyId { get; set; }
        public Attorney BillingAttorney { get; set; }

        [Required]
        public int ResponsibleAttorneyId { get; set; }
        public Attorney ResponsibleAttorney { get; set; }

        public ICollection<Invoice> Invoices { get; set; }
    }
}
