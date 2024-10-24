﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Patient.Application.Account;
using Patient.Application.Users;
using Patient.Domain.Entities;
using Patient.Domain.Exceptions;
using Patient.Domain.Repositories;

namespace Patient.Application.Prescriptions.Commands.Patient.AskForPrescription;

internal class AddPrescriptionRequestCommandHandler(ILogger<AddPrescriptionRequestCommandHandler> logger,
IdentityUserAccessor userAccessor, UserManager<Domain.Entities.Actors.Patient> patientManager,
IUserContext userContext, HttpClient _httpClient,
IPrescriptionRequestRepository prescriptionRequestRepository, 
IDoctorsRepository doctorsRepository) : IRequestHandler<AddPrescriptionRequestCommand, bool>
{
    public async Task<bool> Handle(AddPrescriptionRequestCommand request, CancellationToken cancellationToken)
    {
        var user = await userContext.GetCurrentUserAsync();
        logger.LogInformation($"Adding prescription request for patient user: {user.Id}");

        var patientsDoctor = await doctorsRepository.GetPatientsFirstContactDoctor(user.Id, cancellationToken);
        if (patientsDoctor == null)
        {
            throw new NotFullfilledMedicalInterviewException();
        }

        var prescriptionRequest = new PrescriptionRequest()
        {
            MedicineNames = request.Dto.MedicineNames,
            Description = "",
            DateOfIssue = DateOnly.FromDateTime(DateTime.Today),
            PatientId = user.Id,
            DoctorId = patientsDoctor.Id,

        };
        await prescriptionRequestRepository.AddPrescriptionRequest(prescriptionRequest, cancellationToken);
        logger.LogInformation($"Added prescription request for user: {user.Id}");
        return true;
    }

   
}
