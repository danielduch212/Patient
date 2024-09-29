using AutoMapper;
using Patient.Domain.Entities;
using Patient.Domain.Entities.DTOs.Prescription;
using Patient.Domain.Entities.DTOs.Recommandation;

namespace Patient.Application.Recommandation.Dto;

public class RecommandationProfile : Profile
{
    public RecommandationProfile()
    {
        CreateMap<MedicalRecommandationDto, MedicalRecommandation>();
        CreateMap<PrescriptionDto, Prescription>();

    }
}
