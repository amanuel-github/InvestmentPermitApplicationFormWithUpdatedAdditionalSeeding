using AutoMapper;
using InvestmentPermit.Application.DTOS;
using InvestmentPermit.Domain.Entities;
using InvestmentPermit.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentPermit.Application.Repository.InvestmentPermitDetails
{
    public class InvestmentPermissionRepository
    {
        private readonly InvestmentPermitDbContext context;
        private readonly IMapper _mapper;


        public InvestmentPermissionRepository(InvestmentPermitDbContext _context, IMapper mapper)
        {
            context = _context;
            _mapper = mapper;

        }

        // Get Zone from server cache if there is no cache get from the database
        // and store for other time
        public async Task<bool> saveInvestmentPermit( InvestmentPermitDto investment)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var personalinfomapped = _mapper.Map<PersonalInformation>(investment.PersonalInformation);
                        await context.PersonalInformations.AddAsync(personalinfomapped);
                        await context.SaveChangesAsync();

                        var organizationinfomapped = _mapper.Map<BusinessOrganizationDetails>(investment.BusinessOrganization);
                        await context.BusinessOrganizationDetails.AddAsync(organizationinfomapped);
                        await context.SaveChangesAsync();

                        investment.PersonalInformationId = personalinfomapped.Id.ToString();
                        var datamapped = _mapper.Map<InvestmentPermission>(investment);
                        await context.InvestmentPermissions.AddAsync(datamapped);

                        await context.SaveChangesAsync();
                        transaction.Commit();

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
                return true;
            }
            catch (Exception err)
            {
                return false;
                Console.WriteLine(err);

            }

        }


        
    }
}
