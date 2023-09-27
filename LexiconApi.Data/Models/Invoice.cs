using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconApi.Data.Models
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int HoursWorked { get; set; }
        public float? TotalAmount { get; set; }
        [Required]
        public int MatterId { get; set; }
        public Matter Matter { get; set; }
        [Required]
        public int AttorneyId { get; set; }
        public Attorney Attorney { get; set; }
    }
}
