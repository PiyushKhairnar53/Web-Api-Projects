using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconApi.Data.Models
{
    public class Attorney
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public int Rate { get; set; }

        public int JurisdictionId { get; set; }
        [JsonIgnore]
        public Jurisdiction Jurisdiction { get; set; } = null!;

        public ICollection<Matter> BillingAttorneyMatters { get; set; }
        public ICollection<Matter> ResponsibleAttorneyMatters { get; set; }
        public ICollection<Invoice> Invoices { get; set; }

    }
}
