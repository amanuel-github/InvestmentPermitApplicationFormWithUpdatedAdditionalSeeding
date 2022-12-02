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
    public class WoredaControllers : ControllerBase
    {
        private readonly WoredaRepository _woredaRepo;

        public WoredaControllers(WoredaRepository woredaRepository)
        {
            _woredaRepo = woredaRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<AdressDto>> GetAllWoredas()
        {
            var woredas = await _woredaRepo.GetAllWoredas();
            return woredas;
        }



    }
}