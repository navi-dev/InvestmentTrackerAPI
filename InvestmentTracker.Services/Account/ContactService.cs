using AutoMapper;
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
        private readonly IMapper _mapper;


        public ContactService(InvestmentTrackerDatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool Add(ContactDto contactDto)
        {
            var contact = _mapper.Map<Contacts>(contactDto);
            _context.Contacts.Add(contact);
            var rowsEffected = _context.SaveChanges();

            return true;
        }

        public IList<ContactDto> Get()
        {
            var contacts = _context.Contacts.ToList();
            var contactDto = _mapper.Map<List<ContactDto>>(contacts);

            return contactDto;
        }

        public ContactDto Get(int id)
        {
            var contact = _context.Contacts.FirstOrDefault(elem => elem.Id == id);
            return _mapper.Map<ContactDto>(contact);
        }

        public bool Update(ContactDto contact)
        {
            throw new NotImplementedException();
        }
    }
}
