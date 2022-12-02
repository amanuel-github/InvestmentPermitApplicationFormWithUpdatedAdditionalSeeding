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
    public class KebelleRepository
    {
        private readonly InvestmentPermitDbContext context;


        public KebelleRepository(InvestmentPermitDbContext _context)
        {
            context = _context;
        }

        // Get Zone from server cache if there is no cache get from the database
        // and store for other time
        public async Task<List<AdressDto>> GetKebelesByParentCode( string woredaIdentificationCode)
        {
            List<AdressDto> Keble = null;


            try
            {


                Keble = await context.Kebelles.Where(s => s.ParentIdentifactionCode == woredaIdentificationCode)
                    .Select(z => new AdressDto
                    {
                        Name = z.Name,
                        IdentificationCode = z.IdentifactionCode,
                        Description =  z.Description,
                        ParentIdentifactionCode = z.ParentIdentifactionCode

                    })
                    .AsNoTracking().ToListAsync();



                return Keble;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<List<AdressDto>> GetAllKebeles()
        {
            List<AdressDto> Keble = null;


            try
            {


                Keble = await context.Kebelles
                    .Select(z => new AdressDto
                    {
                        Name=z.Name,
                        IdentificationCode = z.IdentifactionCode,
                        Description =  z.Description,
                        ParentIdentifactionCode = z.ParentIdentifactionCode

                    })
                    .AsNoTracking().ToListAsync();



                return Keble;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}


