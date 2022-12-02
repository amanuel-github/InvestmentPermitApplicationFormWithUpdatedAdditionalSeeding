using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentPermit.Domain.Entities
{
    public class Nationality : CommonEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
