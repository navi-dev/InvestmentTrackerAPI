using InvestmentTracker.Contracts.DomainModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentTracker.Contracts.ServiceInterface
{
    public interface IContactService
    {
        IList<ContactDto> Get();

        ContactDto Get(int id);

        bool Add(ContactDto contact);

        bool Update(ContactDto contact);
    }
}
