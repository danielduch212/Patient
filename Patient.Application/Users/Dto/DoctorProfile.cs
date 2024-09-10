using AutoMapper;
using Patient.Domain.Entities.Actors;
using Patient.Domain.Entities.Additional;

namespace Patient.Application.Users.Dto;

public class DoctorProfile : Profile
{
    public DoctorProfile()
    {
        CreateMap<RegisterDoctorData, Doctor>();

    }
}
