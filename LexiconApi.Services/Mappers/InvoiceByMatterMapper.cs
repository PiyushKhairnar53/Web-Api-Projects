using LexiconApi.Data.Models;
using LexiconApi.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconApi.Services.Mappers
{
    public class InvoiceByMatterMapper
    {
        public InvoicesByMatterDTO Map(Invoice entity)
        {
            return new InvoicesByMatterDTO
            {
                Id = entity.Id,
                Date = entity.Date,
                HoursWorked = entity.HoursWorked,
                TotalAmount = entity.TotalAmount,
                MatterId = entity.MatterId,
                ClientName = entity.Matter.Client.Name,
                MatterTitle = entity.Matter.Title,
                AttorneyName = entity.Attorney.Name,
            };
        }
    }
}
