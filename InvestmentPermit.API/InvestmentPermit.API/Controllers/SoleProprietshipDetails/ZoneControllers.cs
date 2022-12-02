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
    public class ZoneControllers : ControllerBase
    {
        private readonly ZoneRepository _zoneRepo;

        public ZoneControllers(ZoneRepository zoneRepository)
        {
            _zoneRepo = zoneRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<AdressDto>> GetAllZones()
        {
            var zones = await _zoneRepo.GetAllZones();
            return zones;
        }



    }
}