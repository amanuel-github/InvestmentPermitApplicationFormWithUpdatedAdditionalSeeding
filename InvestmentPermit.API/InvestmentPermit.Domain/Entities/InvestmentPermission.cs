using InvestmentPermit.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentPermit.Domain.Entities
{
    public class InvestmentPermission : CommonEntity
    {
        public string FormOfOwnerShip { get; set; }
        public string PersonalInformationId { get; set; }
        public string Tin { get; set; }
        public string RegistrationNumber { get; set; }
        public string TradeName { get; set; }
        public bool IsOpenedDocumentBeforeNow { get; set; }
        public  string BusinessOrganizationId { get; set; }

        public PersonalInformation PersonalInformation { get; set; }
        public BusinessOrganizationDetails BusinessOrganization { get; set; }


    }
}
