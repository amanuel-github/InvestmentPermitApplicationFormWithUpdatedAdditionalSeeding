using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InvestmentPermit.Domain.Entities
{
    public class Kebelle : AdressCommonEntity
    {
        public string Name { get; set; }
        [Key]
        public string IdentifactionCode { get; set; }

        public string Description { get; set; }

        public string ParentIdentifactionCode { get; set; }

        public int Id { get; set; }
    }
}
