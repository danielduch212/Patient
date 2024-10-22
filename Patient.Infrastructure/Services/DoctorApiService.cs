using MediatR;
using Microsoft.AspNetCore.Http;
using Patient.Application.Reports.Queries.Doctor.GetReports;
using Patient.Application.Reports.Queries.Doctor.GetReport;
using Patient.Application.PrescriptionRequests.Commands.Doctor.PrescribePrescriptionFromRequest;
using Patient.Application.PrescriptionRequests.Queries.Doctor.GetDoctorsPrescriptionRequests;
using Patient.Application.Recommandation.Commands.Doctor.CreateRecommandation;
using Patient.Domain.Entities.DTOs.PrescriptionRequest;
using Patient.Domain.Entities.DTOs.Recommandation;
using Patient.Domain.Interfaces;
using System.Text.Json;
using Patient.Application.Users;
using Patient.Domain.Entities.DTOs.Reports;
using Patient.Domain.Entities.DTOs.MedicalFiles;
using Patient.Application.Diseases.Query.Doctor.GetPatientsDiseases;
using Patient.Application.MedicalData.Queries.Doctor.GetPatientsMedicalFiles;
using Shared.Dtos;


namespace Patient.Infrastructure.Services;

public class DoctorApiService : IDoctorApiService
{
    private readonly IMediator _mediator;
    private readonly IUserContext _userContext;

    public DoctorApiService(IMediator mediator, IUserContext userContext)
    {
        _mediator = mediator;
        _userContext = userContext;
    }

    public async Task<List<ReportForDoctorDto>> GetReports(CancellationToken cancellationToken)
    {
        
        var results = await _mediator.Send(new GetReportsForDoctorQuery(), cancellationToken);
        return results;
    }

    public async Task<ReportForDoctorToShowDto> GetReport(string id, CancellationToken cancellationToken)
    {       
        var result = await _mediator.Send(new GetReportForDoctorQuery { Id = id }, cancellationToken);
        return result;
    }

    public async Task<bool> AddRecommandation(MedicalRecommandationDto dto, CancellationToken cancellationToken)
    {

        var response = await _mediator.Send(new CreateRecommandationCommand { MedicalRecommandationDto = dto }, cancellationToken);
        return response;
    }

    public async Task<List<PrescriptionRequestToShowToDoctorDto>> GetPrescriptionRequests(CancellationToken cancellationToken)
    {
        var results = await _mediator.Send(new GetDoctorsPrescriptionRequestsQuery(), cancellationToken);
        return results;
    }

    public async Task<bool> PrescribePrescription(PrescriptionRequestToShowToDoctorDto dto, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new PrescribePrescriptionFromRequestCommand { Dto = dto }, cancellationToken);
        return result;
    }

    public async Task<List<PatientsDiseaseDto>> GetPatientsDiseases(string patientId, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetPatientsDiseasesQuery {PatientId = patientId }, cancellationToken);
        return result;
    }

    public async Task<List<MedicalFileToShowDto>> GetPatientsMedicalDoc(string patientId, CancellationToken cancellationToken)
    {
        var query = new GetPatientsMedicalFilesQuery(){
            PatientId = patientId,
        };
        var result = await _mediator.Send(query, cancellationToken);
        return result;
    }
}
