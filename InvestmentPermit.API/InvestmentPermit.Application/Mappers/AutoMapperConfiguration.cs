using AutoMapper;
using InvestmentPermit.Application.DTOS;
using InvestmentPermit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentPermit.Application.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PersonalInformation, PersonalInformationDto>();
             CreateMap<InvestmentPermission, InvestmentPermitDto>();
            CreateMap<BusinessOrganizationDetails, BusinessOrganizationDetailsDto>();
        }
    }
}