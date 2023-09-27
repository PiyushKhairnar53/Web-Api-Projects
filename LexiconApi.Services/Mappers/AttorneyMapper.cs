using AutoMapper;
using LexiconApi.Data.Models;
using LexiconApi.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconApi.Services.Mappers
{
    public class AttorneyMapper 
    {
        public AttorneyDTO Map(Attorney entity)
        {
            return new AttorneyDTO
            {
                
                Id = entity.Id,
                Name = entity.Name,
                Age = entity.Age,
                Email = entity.Email,
                Phone = entity.Phone,
                Rate = entity.Rate,
                JurisdictionId = entity.JurisdictionId
            };
        }
    }

}
