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
    public class RegionControllers : ControllerBase
    {
        private readonly RegionRepository _regionRepo;

        public RegionControllers(RegionRepository regionRepository)
        {
            _regionRepo = regionRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<AdressDto>> GetAllRegions()
        {
            var regions = await _regionRepo.GetAllRegionss();
            return regions;
        }



    }
}
