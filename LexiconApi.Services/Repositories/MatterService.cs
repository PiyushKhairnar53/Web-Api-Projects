using AutoMapper;
using LexiconApi.Data.DBContext;
using LexiconApi.Data.Models;
using LexiconApi.Services.DTOs;
using LexiconApi.Services.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconApi.Services.Repositories
{
    public interface IMatterService
    {
        public IEnumerable<IGrouping<int, Matter>> GetAllMatters();
        public Matter AddMatter(MatterDTO matter);
        public IEnumerable<MatterDTO> GetMattersForClient(int clientId);

    }
    public class MatterService : IMatterService
    {
        private readonly LexiconDBContext _lexiconDBContext;
        private readonly IMapper _mapper;
        public MatterService(LexiconDBContext lexiconDBContext, IMapper mapper)
        {
            _lexiconDBContext = lexiconDBContext;
            _mapper = mapper;
        }

        public IEnumerable<IGrouping<int, Matter>> GetAllMatters()
        {
            IEnumerable<IGrouping<int,Matter>> matterList = _lexiconDBContext.Matters.GroupBy(s => s.ClientId).ToList();
            //var matters = _lexiconDBContext.Matters.ToList();
            return matterList;
        }


        public Matter AddMatter(MatterDTO matter)
        {
            try
            {
                Attorney attorney = _lexiconDBContext.Attorneys.FirstOrDefault(s => s.Id == matter.BillingAttorneyId);

                if (attorney!.JurisdictionId == matter.JurisdictionId) 
                {
                    var newMatter = new Matter
                    {
                        Id = matter.Id,
                        Title = matter.Title,
                        IsActive = matter.IsActive,
                        JurisdictionId = matter.JurisdictionId,
                        ClientId = matter.ClientId,
                        BillingAttorneyId = matter.BillingAttorneyId,
                        ResponsibleAttorneyId = matter.ResponsibleAttorneyId

                    };
                    _lexiconDBContext.Matters.Add(newMatter);
                    _lexiconDBContext.SaveChanges();

                    return newMatter;
                }
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public IEnumerable<MatterDTO> GetMattersForClient(int clientId)
        {
            var mattersByClient = _lexiconDBContext.Matters.Where(c => c.ClientId.Equals(clientId));
            return mattersByClient.Select(c => new MatterMapper().Map(c)).ToList();
        }

    }
}