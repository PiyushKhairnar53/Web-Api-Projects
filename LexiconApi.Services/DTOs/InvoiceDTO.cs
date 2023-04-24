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
    public class InvoiceDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int HoursWorked { get; set; }
        [JsonIgnore]
        public float? TotalAmount { get; set; }
        [Required]
        public int MatterId { get; set; }
        [Required]
        public int AttorneyId { get; set; }
    }
}
