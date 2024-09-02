using AutoMapper;
using Patient.Application.Users.Commands.Patients.Register;
using Patient.Domain.Entities.Actors;


namespace Patient.Application.Users.Dto;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<RegisterPatientCommand, Patient.Domain.Entities.Actors.Patient>();
    }
}
