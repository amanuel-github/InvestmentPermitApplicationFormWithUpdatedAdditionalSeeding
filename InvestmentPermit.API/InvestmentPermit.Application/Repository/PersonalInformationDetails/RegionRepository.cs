using InvestmentPermit.Application.DTOS;
using InvestmentPermit.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentPermit.Application.Repository.PersonalInformationDetails
{

    public class RegionRepository
    {
        private readonly InvestmentPermitDbContext context;


        public RegionRepository(InvestmentPermitDbContext _context)
        {
            context = _context;
        }

        // Get Zone from server cache if there is no cache get from the database
        // and store for other time
       

        public async Task<List<AdressDto>> GetAllRegionss()
        {
            List<AdressDto> region = null;


            try
            {


                region = await context.Regions
                    .Select(z => new AdressDto
                    {
                        Name = z.Name,
                        IdentificationCode = z.IdentifactionCode,
                        Description = z.Description,
                        

                    })
                    .AsNoTracking().ToListAsync();



                return region;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}


