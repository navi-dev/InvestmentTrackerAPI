using System.Collections.Generic;
using InvestmentTracker.Contracts.DomainModel;
using InvestmentTracker.Contracts.ServiceInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentTracker.Controllers
{
    [ApiController]
    public class ContactsController : ControllerBase
    {
        IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        [Route("api/[Controller]")]
        [Authorize]
        public ActionResult<IEnumerable<string>> Get()
        {
            var contacts = _contactService.Get();
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        [Route("api/[Controller]/{contactId}")]
        public ActionResult<string> Get(int contactId)
        {
            var contacts = _contactService.Get(contactId);
            return "value1";
        }

        [HttpPost]
        [Route("api/[Controller]/create")]
        public ActionResult<string> CreateContact(ContactDto contact)
        {
            var contacts = _contactService.Add(contact);
            return "value1";
        }

        [HttpPut]
        [Route("api/[Controller]/modify")]
        public ActionResult<string> UpdateContact(ContactDto contact)
        {
            //var contacts = _contactService.Get();
            return "value1";
        }
    }
}