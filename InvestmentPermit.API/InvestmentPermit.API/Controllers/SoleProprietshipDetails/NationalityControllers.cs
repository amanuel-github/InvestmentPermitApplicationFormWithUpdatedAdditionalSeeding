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
    public class NationalityControllers : ControllerBase
    {

        private readonly NationalityRepository _nationalityRepo;

        public NationalityControllers(NationalityRepository nationalityRepository)
        {
            _nationalityRepo = nationalityRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<AdressDto>> GetAllNationalities()
        {
            var nationalities = await _nationalityRepo.GetAllNationalities();
            return nationalities;
        }
    }
}