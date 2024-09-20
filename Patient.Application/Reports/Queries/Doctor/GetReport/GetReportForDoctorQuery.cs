using MediatR;
using Patient.Domain.Entities.DTOs;
using Patient.Domain.Entities;

namespace Patient.Application.Reports.Queries.Doctor.GetReport;

public class GetReportForDoctorQuery : IRequest<ReportToShowToDoctorDto>
{
    public string Id { get; set; }
}
