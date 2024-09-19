using MediatR;
using Patient.Domain.Entities.DTOs;
using Patient.Domain.Entities;

namespace Patient.Application.Reports.Queries.GetReport;

public class GetReportQuery : IRequest<ReportToShowDto>
{
    public string Id { get; set; }
}
