using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentPermit.Domain.Entities
{
    public class AdressCommonEntity
    {
        public string CreatedUserId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedUserId { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }
    }
}
