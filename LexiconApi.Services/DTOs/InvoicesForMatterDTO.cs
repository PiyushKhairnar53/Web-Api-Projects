using LexiconApi.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconApi.Services.DTOs
{
    public class InvoicesForMatterDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int HoursWorked { get; set; }
        public float? TotalAmount { get; set; }
        public string ClientName { get; set; }
        public string MatterTitle { get; set; }
        public string AttorneyName { get; set; }

    }
}
