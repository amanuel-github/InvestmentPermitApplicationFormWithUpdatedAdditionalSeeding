using InvestmentPermit.Application.DTOS;
using InvestmentPermit.Application.Repository.PersonalInformationDetails;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InvestmentPermit.API.Controllers.SoleProprietshipDetails
{
    [Route("api/[controller]")]
    [ApiController]
    public class KebelleControllers : ControllerBase
    {
        
            private readonly KebelleRepository _kebelleRepo;

            public KebelleControllers(KebelleRepository kebeleRepository)
            {
                _kebelleRepo = kebeleRepository;
            }

            [HttpGet]
            public async Task<IEnumerable<AdressDto>> GetAllKebeles()
            {
                var kebeles = await _kebelleRepo.GetAllKebeles();
                return kebeles;
            }
          



        
    

}
}
