using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvestmentTracker.Contracts.DomainModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentTracker.Controllers
{
    [ApiController]
    public class ContactsController : ControllerBase
    {
        [HttpGet]
        [Route("api/[Controller]")]
        [Authorize]
        public ActionResult<IEnumerable<string>> Get()
        {
            //var contacts = _contactService.Get();
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        [Route("api/[Controller]/{contactId}")]
        public ActionResult<string> Get(int contactId)
        {
            //var contacts = _contactService.Get();
            return "value1";
        }

        [HttpPost]
        [Route("api/[Controller]/create")]
        public ActionResult<string> CreateContact(ContactDto contact)
        {
            //var contacts = _contactService.Get();
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