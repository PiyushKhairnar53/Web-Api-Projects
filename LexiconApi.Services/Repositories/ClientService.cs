using AutoMapper;
using LexiconApi.Data.DBContext;
using LexiconApi.Data.Models;
using LexiconApi.Services.DTOs;
using LexiconApi.Services.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconApi.Services.Repositories
{
    public interface IClientService
    {
        public IEnumerable<ClientDTO> GetAllClients();
        public Client AddClient (ClientDTO client);
    }
    public class ClientService : IClientService
    {
        private readonly LexiconDBContext _lexiconDBContext;
        private readonly IMapper _mapper;
        public ClientService(LexiconDBContext lexiconDBContext, IMapper mapper)
        {
            _lexiconDBContext = lexiconDBContext;
            _mapper = mapper;
        }

        public Client AddClient(ClientDTO entity)
        {
            try
            {
                var newClient = new Client
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Age = entity.Age,
                    Gender = entity.Gender,
                    Email = entity.Email,
                    Phone = entity.Phone,

                };
                _lexiconDBContext.Clients.Add(newClient);
                _lexiconDBContext.SaveChanges();
                return newClient;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public IEnumerable<ClientDTO> GetAllClients()
        {
            var clients = _lexiconDBContext.Clients.ToList();
            return clients.Select(c => new ClientMapper().Map(c)).ToList();
        }
    }
}
