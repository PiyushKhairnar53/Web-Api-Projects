using LexiconApi.Data.Models;
using LexiconApi.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconApi.Services.Mappers
{
    public class JurisdictionMapper
    {
        public JurisdictionDTO Map(Jurisdiction entity)
        {
            return new JurisdictionDTO
            {
                Id = entity.Id,
                Area = entity.Area,         
            };
        }
    }
}
