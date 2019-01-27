using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentTracker.Contracts.DomainModel
{
    public class ContactDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public short ContactType { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public string EmailId { get; set; }
    }
}
