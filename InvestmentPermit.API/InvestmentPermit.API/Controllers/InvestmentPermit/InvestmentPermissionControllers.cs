using InvestmentPermit.Application.DTOS;
using InvestmentPermit.Application.Repository.InvestmentPermitDetails;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InvestmentPermit.API.Controllers.InvestmentPermit
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestmentPermissionControllers : ControllerBase
    {
        private readonly InvestmentPermissionRepository _invesRepo;

        public InvestmentPermissionControllers(InvestmentPermissionRepository invesRepository)
        {
            _invesRepo = invesRepository;
        }



        [HttpPost]
        public async Task<bool> AddInvestmentPermision([FromBody]InvestmentPermitDto investment)
        {
            return await _invesRepo.saveInvestmentPermit(investment);
        }

    

    }
}
