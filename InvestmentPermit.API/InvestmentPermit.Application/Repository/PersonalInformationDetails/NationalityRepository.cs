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
    public class NationalityRepository
    {
        private readonly InvestmentPermitDbContext context;


        public NationalityRepository(InvestmentPermitDbContext _context)
        {
            context = _context;
        }

        // Get Zone from server cache if there is no cache get from the database
        // and store for other time


        public async Task<List<AdressDto>> GetAllNationalities()
        {
            List<AdressDto> nationality = null;


            try
            {


                nationality = await context.Nationalities
                    .Select(z => new AdressDto
                    {
                        Name = z.Name,
                        Description = z.Description,


                    })
                    .AsNoTracking().ToListAsync();



                return nationality;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}

