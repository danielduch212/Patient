﻿using AutoMapper;
using Patient.Domain.Entities.Actors;
using Patient.Domain.Entities.Additional;

namespace Patient.Application.Users.Dto;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<RegisterUserData, Patient.Domain.Entities.Actors.Patient>();
        
    }
}
