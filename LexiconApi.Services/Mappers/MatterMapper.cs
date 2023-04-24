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
    public class MatterMapper
    {
        public MatterDTO Map(Matter entity)
        {
            return new MatterDTO
            {
                Id = entity.Id,
                Title = entity.Title,
                IsActive = entity.IsActive,
                JurisdictionId = entity.JurisdictionId,
                ClientId = entity.ClientId,
                BillingAttorneyId = entity.BillingAttorneyId,
                ResponsibleAttorneyId = entity.ResponsibleAttorneyId
            };
        }
    }
}
