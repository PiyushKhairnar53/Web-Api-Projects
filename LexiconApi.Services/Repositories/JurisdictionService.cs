﻿using AutoMapper;
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
    public interface IJurisdictionService 
    {
        public IEnumerable<JurisdictionDTO> GetAllJurisdictions();
        public Jurisdiction AddJurisdiction(JurisdictionDTO entity);

    }

    public class JurisdictionService : IJurisdictionService
    {
        private readonly LexiconDBContext _lexiconDBContext;
        private readonly IMapper _mapper;
        public JurisdictionService(LexiconDBContext lexiconDBContext, IMapper mapper)
        {
            _lexiconDBContext = lexiconDBContext;
            _mapper = mapper;
        }

        public IEnumerable<JurisdictionDTO> GetAllJurisdictions()
        {
            var jurisdictions = _lexiconDBContext.Jurisdictions.ToList();
            return jurisdictions.Select(c => new JurisdictionMapper().Map(c)).ToList();
        }

        public Jurisdiction AddJurisdiction(JurisdictionDTO entity)
        {
            try
            {
                var newJurisdiction = new Jurisdiction
                {
                    Id = entity.Id,
                    Area = entity.Area,             
                };
                _lexiconDBContext.Jurisdictions.Add(newJurisdiction);
                _lexiconDBContext.SaveChanges();
                return newJurisdiction;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
