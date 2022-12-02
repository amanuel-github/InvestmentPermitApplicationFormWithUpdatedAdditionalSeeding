using InvestmentPermit.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentPermit.Application.DTOS
{
    public class InvestmentPermitDto
    {
        public string FormOfOwnerShip { get; set; }
        public string PersonalInformationId { get; set; }
        public string Tin { get; set; }
        public string RegistrationNumber { get; set; }
        public string TradeName { get; set; }
        public bool IsOpenedDocumentBeforeNow { get; set; }
        public string BusinessOrganizationId { get; set; }
        public PersonalInformationDto PersonalInformation { get; set; }
        public BusinessOrganizationDetailsDto BusinessOrganization { get; set; }
    }
}
