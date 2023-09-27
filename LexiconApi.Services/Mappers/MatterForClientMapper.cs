using LexiconApi.Data.Models;
using LexiconApi.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconApi.Services.Mappers
{
    public class MatterForClientMapper
    {
        public MatterForClientDTO Map(Matter entity)
        {
            return new MatterForClientDTO
            {
                Id = entity.Id,
                Title = entity.Title,
                IsActive = entity.IsActive,
                Description = entity.Description,
                Category = entity.Category,
                ClientName = entity.Client.Name,
                JurisdictionArea = entity.Jurisdiction.Area,
                BillingAttorneyName = entity.BillingAttorney.Name,
                ResponsibleAttorneyeName = entity.ResponsibleAttorney.Name
            };
        }
    }
}
