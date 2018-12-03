using InvestmentTracker.Contracts.DomainModel;
using InvestmentTracker.Contracts.ServiceInterface;
using InvestmentTracker.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InvestmentTracker.Services.Account
{
    public class ContactService : IContactService
    {
        private readonly InvestmentTrackerDatabaseContext _context;

        public ContactService(InvestmentTrackerDatabaseContext context)
        {
            _context = context;
        }

        public bool Add(ContactDto contact)
        {
            throw new NotImplementedException();
        }

        public IList<ContactDto> Get()
        {
            return _context.Contacts.Select(elem => new ContactDto()
            {
                Id = elem.Id,
                Name = elem.Name,
            }).ToList();
        }

        public ContactDto Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(ContactDto contact)
        {
            throw new NotImplementedException();
        }
    }
}
