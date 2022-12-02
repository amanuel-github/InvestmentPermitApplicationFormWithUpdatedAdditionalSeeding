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
    public class ZoneRepository
    {
        private readonly InvestmentPermitDbContext context;


        public ZoneRepository(InvestmentPermitDbContext _context)
        {
            context = _context;
        }

        // Get Zone from server cache if there is no cache get from the database
        // and store for other time
        public async Task<List<AdressDto>> GetZonesByParentCode(string regionIdentificationCode)
        {
            List<AdressDto> zone = null;


            try
            {


                zone = await context.Zones.Where(s => s.ParentIdentifactionCode == regionIdentificationCode)
                    .Select(z => new AdressDto
                    {
                        Name = z.Name,
                        IdentificationCode = z.IdentifactionCode,
                        Description = z.Description,
                        ParentIdentifactionCode = z.ParentIdentifactionCode

                    })
                    .AsNoTracking().ToListAsync();



                return zone;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<List<AdressDto>> GetAllZones()
        {
            List<AdressDto> zone = null;


            try
            {


                zone = await context.Zones
                    .Select(z => new AdressDto
                    {
                        Name = z.Name,
                        IdentificationCode = z.IdentifactionCode,
                        Description = z.Description,
                        ParentIdentifactionCode = z.ParentIdentifactionCode

                    })
                    .AsNoTracking().ToListAsync();



                return zone;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}


