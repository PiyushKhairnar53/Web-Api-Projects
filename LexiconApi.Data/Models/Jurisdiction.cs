using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconApi.Data.Models
{
    public class Jurisdiction
    {
        [Key]
        public int Id { get; set; }
        public string Area { get; set; } = null!;
        public ICollection<Attorney> Attorneys { get; set; }
        public ICollection<Matter> Matters { get; set; }
    }
}
