using MediatR;
using Patient.Domain.Entities.DTOs;
using Patient.Domain.Entities;

namespace Patient.Application.Reports.Queries.Patient.GetReport;

public class GetReportForPatientQuery : IRequest<ReportToShowToPatientDto>
{
    public string Id { get; set; }
}
