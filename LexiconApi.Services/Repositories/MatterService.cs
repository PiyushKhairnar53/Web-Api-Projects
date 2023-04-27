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
        public IEnumerable<MatterDTO> GetAllMatters();
        public IEnumerable<IGrouping<int, MatterByClientDTO>> GetMattersByClient();
        public Matter AddMatter(MatterDTO matter);
        public IEnumerable<MatterForClientDTO> GetMattersForClient(int clientId);

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

        public IEnumerable<MatterDTO> GetAllMatters()
        {
            var allMatters = _lexiconDBContext.Matters.ToList();
            return allMatters.Select(c => new MatterMapper().Map(c)).ToList();
        }

        public IEnumerable<IGrouping<int, MatterByClientDTO>> GetMattersByClient()
        {
            var matterList = _lexiconDBContext.Matters
                .Include(m => m.BillingAttorney)
                .Include(m => m.ResponsibleAttorney)
                .Include(m => m.Jurisdiction)
                .Include(m => m.Client)
                .Select(c => new MatterByClientMapper().Map(c)).AsEnumerable()
                .GroupBy(s => s.ClientId).ToList();
            //var matters = _lexiconDBContext.Matters.ToList();
            return matterList;
        }


        public Matter AddMatter(MatterDTO matter)
        {
            try
            {
                var newMatter = new Matter
                {
                    Id = matter.Id,
                    Title = matter.Title,
                    IsActive = matter.IsActive,
                    Description = matter.Description,
                    Category = matter.Category,
                    JurisdictionId = matter.JurisdictionId,
                    ClientId = matter.ClientId,
                    BillingAttorneyId = matter.BillingAttorneyId,
                    ResponsibleAttorneyId = matter.ResponsibleAttorneyId

                };
                _lexiconDBContext.Matters.Add(newMatter);
                _lexiconDBContext.SaveChanges();

                return newMatter;
                
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public IEnumerable<MatterForClientDTO> GetMattersForClient(int clientId)
        {
            var mattersByClient = _lexiconDBContext.Matters
                .Include(m => m.BillingAttorney)
                .Include(m => m.ResponsibleAttorney)
                .Include(m => m.Jurisdiction)
                .Include(m => m.Client)
                .Where(c => c.ClientId.Equals(clientId));
            return mattersByClient.Select(c => new MatterForClientMapper().Map(c)).ToList();
        }

    }
}