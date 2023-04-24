using LexiconApi.Data.Models;
using LexiconApi.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconApi.Services.Mappers
{
    public class ClientMapper
    {
        public ClientDTO Map(Client entity)
        {

            return new ClientDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Age = entity.Age,
                Gender = entity.Gender,
                Email = entity.Email,
                Phone = entity.Phone,
            };
        }
    }
}
