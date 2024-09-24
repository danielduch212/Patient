using MediatR;
using Patient.Domain.Entities;
using Patient.Domain.Entities.DTOs.Reports;

namespace Patient.Application.Reports.Queries.Doctor.GetReport;

public class GetReportForDoctorQuery : IRequest<ReportForDoctorToShowDto>
{
    public string Id { get; set; }
}
