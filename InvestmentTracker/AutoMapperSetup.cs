using AutoMapper;
using InvestmentTracker.Contracts.DomainModel;
using InvestmentTracker.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestmentTracker
{
    public class AutoMapperSetup: Profile
    {
        public AutoMapperSetup()
        {
            CreateMap<ContactDto, Contacts>();
        }
    }
}
