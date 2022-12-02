using InvestmentPermit.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentPermit.Application.DTOS
{
   public class PersonalInformationDto 
    {
        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string GrandName { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string Region { get; set; }
        public string Zone { get; set; }
        public string Woreda { get; set; }
        public string Kebelle { get; set; }
        public string HouseNo { get; set; }
        public string Country { get; set; }
        public string OtherAdress { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Pobox { get; set; }
    }
}
