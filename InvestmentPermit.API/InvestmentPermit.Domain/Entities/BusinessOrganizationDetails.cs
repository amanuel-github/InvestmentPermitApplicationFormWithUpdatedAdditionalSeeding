using InvestmentPermit.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentPermit.Domain.Entities
{
  public class BusinessOrganizationDetails : CommonEntity
    {
        public BusinessOrganizationDetails() {
            this.InvestmentPermits = new HashSet<InvestmentPermission>();
        }
        public string BusinessOrganizationName { get; set; }
        public string LegalStatus { get; set; }
        public ICollection<InvestmentPermission> InvestmentPermits { get; set; }
    }
}
