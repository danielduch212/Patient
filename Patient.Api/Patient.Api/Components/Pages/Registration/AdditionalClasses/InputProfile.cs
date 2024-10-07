using AutoMapper;
using Patient.Domain.Entities.Actors;
using Patient.Domain.Entities.Additional;

namespace Patient.Api.Components.Pages.Registration.AdditionalClasses;

public class InputProfile : Profile
{
    public InputProfile()
    {

        CreateMap<InputRegisterPatientModel, Patient.Domain.Entities.Actors.Patient>()
        .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
        .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
        .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
        .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
        .ForMember(dest => dest.Address, opt => opt.MapFrom(src => new Address
        {
            City = src.City,
            Street = src.Street,
            PostalCode = src.PostalCode
        }));

        CreateMap<InputRegisterDoctorModel, Doctor>()
        .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
        .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
        .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
        .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
        .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
        .ForMember(dest => dest.DoctorNumber, opt => opt.MapFrom(src => src.DoctorNumber))
        .ForMember(dest => dest.Address, opt => opt.MapFrom(src => new Address
        {
            City = src.City,
            Street = src.Street,
            PostalCode = src.PostalCode
        }));

    }
}
