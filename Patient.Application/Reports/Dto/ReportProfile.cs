﻿using AutoMapper;
using Patient.Domain.Entities;
using Patient.Domain.Entities.DTOs.Reports;
using Shared.AdditionalClasses;

namespace Patient.Application.Reports.Dto;


public class ReportProfile : Profile
{
    public ReportProfile()
    {
        CreateMap<Report, ReportToShowToPatientDto>();

    }

}
