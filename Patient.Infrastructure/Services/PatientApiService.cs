using MediatR;
using Microsoft.AspNetCore.Http;
using Patient.Domain.Entities.DTOs.MedicalFiles;
using Patient.Domain.Entities.DTOs.PrescriptionRequest;
using Patient.Domain.Entities.DTOs.Recommandation;
using Patient.Application.Diseases.Command.Patient.AddPatientsDiseases;
using Patient.Application.Diseases.Query.GetPatientsDiseases;
using Patient.Application.MedicalData.Commands.Patient.AddMedicalFiles;
using Patient.Application.MedicalData.Queries.Patient.GetMedicalFiles;
using Patient.Application.Prescriptions.Queries.Patient.GetPatientPrescriptions;
using Patient.Application.Reports.Queries.Patient.GetReports;
using Patient.Application.Reports.Queries.Patient.GetReport;
using Patient.Domain.Interfaces;
using System.Text.Json;
using Patient.Application.Prescriptions.Commands.Patient.AskForPrescription;
using Patient.Application.Users;
using Shared.Dtos;
using Patient.Domain.Entities.DTOs.Reports;
using Patient.Domain.Entities.DTOs.Prescription;

namespace Patient.Infrastructure.Services;

internal class PatientApiService : IPatientApiService
{
    private readonly IMediator _mediator;
    private readonly IUserContext _userContext;

    public PatientApiService(IMediator mediator, IUserContext userContext)
    {
        _mediator = mediator;
        _userContext = userContext;
    }

    // MedicalFiles
    public async Task<bool> AddMedicalFiles(List<MedicalFileDto> medicalFileDtos, CancellationToken cancellationToken)
    {
        var command = new AddMedicalFilesCommand
        {
            medicalFileDtos = medicalFileDtos
        };
        var result = await _mediator.Send(command, cancellationToken);
        return result;
    }

    public async Task<List<MedicalFileToShowDto>> GetMedicalFiles(CancellationToken cancellationToken)
    {
        var query = new GetMedicalFilesQuery();
        var result = await _mediator.Send(query, cancellationToken);
        return result;
    }

    // Reports
    public async Task<List<ReportToShowToPatientDto>> GetReports(CancellationToken cancellationToken)
    {
        var query = new GetReportsForPatientQuery();
        var results = await _mediator.Send(query, cancellationToken);
        
        return results;
    }

    public async Task<ReportToShowToPatientDto> GetReport(string id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetReportForPatientQuery { Id = id }, cancellationToken);
        return result;
    }

    // Prescriptions
    public async Task<List<PrescriptionToShowPatientDto>> GetPrescriptions(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetPatientsPrescriptionsQuery(), cancellationToken);
        return result;
    }

    public async Task<bool> AddPrescriptionRequest(PrescriptionRequestDto dto, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new AddPrescriptionRequestCommand { Dto = dto }, cancellationToken);
        return result;
    }

    // Diseases
    public async Task<bool> AddPatientsDiseases(List<PatientsDiseaseDto> dtos, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new AddPatientsDiseasesCommand { Dtos = dtos }, cancellationToken);
        return result;
    }

    public async Task<List<PatientsDiseaseDto>> GetPatientsDiseases(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetPatientsDiseasesQuery(), cancellationToken);
        return result;
    }
}
