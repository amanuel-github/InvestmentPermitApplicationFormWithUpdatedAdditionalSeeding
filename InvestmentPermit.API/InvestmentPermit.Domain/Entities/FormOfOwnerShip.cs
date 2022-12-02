using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentPermit.Domain.Entities
{
    public class FormOfOwnerShip : CommonEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
