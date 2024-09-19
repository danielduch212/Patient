using MediatR;
using Patient.Domain.Entities.DTOs;
using Patient.Domain.Entities;

namespace Patient.Application.Reports.Queries.GetReports;

public class GetReportsQuery : IRequest<List<ReportToShowDto>>
{

}
