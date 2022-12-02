using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InvestmentPermit.Domain.Entities
{
    public class Region : AdressCommonEntity
    {
        public string Name { get; set; }
        [Key]
        public string IdentifactionCode { get; set; }

        public string Description { get; set; }


        public int Id { get; set; }
    }
}
