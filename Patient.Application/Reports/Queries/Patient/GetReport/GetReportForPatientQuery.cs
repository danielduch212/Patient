using MediatR;
using Patient.Domain.Entities;
using Patient.Domain.Entities.DTOs.Reports;

namespace Patient.Application.Reports.Queries.Patient.GetReport;

public class GetReportForPatientQuery : IRequest<ReportToShowToPatientDto>
{
    public string Id { get; set; }
}
