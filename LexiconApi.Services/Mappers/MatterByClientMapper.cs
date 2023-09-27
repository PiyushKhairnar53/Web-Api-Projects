using LexiconApi.Data.Models;
using LexiconApi.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconApi.Services.Mappers
{
    public class MatterByClientMapper
    {
        public MatterByClientDTO Map(Matter entity)
        {
            return new MatterByClientDTO
            {
                Id = entity.Id,
                Title = entity.Title,
                Category = entity.Category,
                ClientId = entity.Client.Id,
                ClientName = entity.Client.Name,
                JurisdictionArea = entity.Jurisdiction.Area,
                BillingAttorneyName = entity.BillingAttorney.Name,
                ResponsibleAttorneyeName = entity.ResponsibleAttorney.Name
            };
        }
    }
}
