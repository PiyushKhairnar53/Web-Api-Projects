using LexiconApi.Data.Models;
using LexiconApi.Services.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconApi.Services.Mappers
{
    public class InvoiceMapper
    {
        public InvoiceDTO Map(Invoice entity)
        {
            return new InvoiceDTO
            {
                Id = entity.Id,
                Date = entity.Date,
                HoursWorked = entity.HoursWorked,
                TotalAmount = entity.TotalAmount,
                MatterId = entity.MatterId,
                AttorneyId = entity.AttorneyId,
            };
        }
    }
}
