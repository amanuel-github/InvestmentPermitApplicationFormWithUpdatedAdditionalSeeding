using InvestmentPermit.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentPermit.Application.DTOS
{
    public class BusinessOrganizationDetailsDto
    {
        public string BusinessOrganizationName { get; set; }
        public string LegalStatus { get; set; }
    }
}
