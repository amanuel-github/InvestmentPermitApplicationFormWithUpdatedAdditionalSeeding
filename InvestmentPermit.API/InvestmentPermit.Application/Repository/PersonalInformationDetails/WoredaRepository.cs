using InvestmentPermit.Application.DTOS;
using InvestmentPermit.Domain.Settings;
using InvestmentPermit.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentPermit.Application.Repository.PersonalInformationDetails
{
   
        public class WoredaRepository
        {
            private readonly InvestmentPermitDbContext context;
            

            public WoredaRepository(InvestmentPermitDbContext _context)
            {
                context = _context;
            }

            
        public async Task<List<AdressDto>> GetAllWoredas()
        {
            List<AdressDto> Woreda = null;


            try
            {


                Woreda = await context.Woredas
                    .Select(z => new AdressDto
                    {
                        Name = z.Name,
                        IdentificationCode = z.IdentifactionCode,
                        Description = z.Description,
                        ParentIdentifactionCode = z.ParentIdentifactionCode

                    })
                    .AsNoTracking().ToListAsync();



                return Woreda;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}




        
    


