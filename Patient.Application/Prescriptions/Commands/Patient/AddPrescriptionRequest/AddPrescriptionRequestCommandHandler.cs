﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Patient.Application.Account;
using Patient.Domain.Entities;
using Patient.Domain.Repositories;

namespace Patient.Application.Prescriptions.Commands.Patient.AskForPrescription;

internal class AddPrescriptionRequestCommandHandler(ILogger<AddPrescriptionRequestCommandHandler> logger,
IdentityUserAccessor userAccessor, UserManager<Domain.Entities.Actors.Patient> patientManager,
IHttpContextAccessor httpContextAccesor, HttpClient _httpClient,
IPrescriptionRequestRepository prescriptionRequestRepository, 
IDoctorsRepository doctorsRepository) : IRequestHandler<AddPrescriptionRequestCommand, bool>
{
    public async Task<bool> Handle(AddPrescriptionRequestCommand request, CancellationToken cancellationToken)
    {
        var user = await userAccessor.GetRequiredUserAsync(httpContextAccesor.HttpContext);
        logger.LogInformation($"Adding prescription request for patient user: {user.Id}");

        var patientsDoctor = await doctorsRepository.GetPatientsDoctor(user.Id);

        var prescriptionRequest = new PrescriptionRequest()
        {
            MedicineNames = request.Dto.MedicineNames,
            Description = "",
            DateOfIssue = DateOnly.FromDateTime(DateTime.Today),
            PatientId = user.Id,
            DoctorId = patientsDoctor.Id,

        };
        await prescriptionRequestRepository.AddPrescriptionRequest(prescriptionRequest);
        logger.LogInformation($"Added prescription request for user: {user.Id}");
        return true;
    }

   
}
