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
    public interface IAttorneyService 
    {
        public IEnumerable<AttorneyDTO> GetAllAttorneys();
        public Attorney AddAttorney(AttorneyDTO attorney);
        public IEnumerable<AttorneyDTO> GetAttorneysForJurisdiction(int jurisdictionId);
    }
    public class AttorneyService:IAttorneyService
    {
        private readonly LexiconDBContext _lexiconDBContext;
        private readonly IMapper _mapper;
        public AttorneyService(LexiconDBContext lexiconDBContext, IMapper mapper)
        {
            _lexiconDBContext = lexiconDBContext;
            _mapper = mapper;
        }

        public IEnumerable<AttorneyDTO> GetAllAttorneys()
        {
            var attorneys = _lexiconDBContext.Attorneys.ToList();
            return attorneys.Select(c => new AttorneyMapper().Map(c)).ToList();
        }

        public IEnumerable<AttorneyDTO> GetAttorneysForJurisdiction(int jurisdictionId)
        {
            var attorneysForJurisdiction = _lexiconDBContext.Attorneys.Where(c => c.JurisdictionId.Equals(jurisdictionId));
            return attorneysForJurisdiction.Select(c => new AttorneyMapper().Map(c)).ToList();
        }

        public Attorney AddAttorney(AttorneyDTO attorney)
        {
            try
            {
                var newAttorney = new Attorney
                {
                    Name = attorney.Name,
                    Age = attorney.Age,
                    Email = attorney.Email,
                    Phone = attorney.Phone,
                    Rate = attorney.Rate,
                    JurisdictionId = attorney.JurisdictionId

                };
                _lexiconDBContext.Attorneys.Add(newAttorney);
                _lexiconDBContext.SaveChanges();
                return newAttorney;
            }
            catch (Exception e) 
            {
                return null;
            }
        }
    }
}
