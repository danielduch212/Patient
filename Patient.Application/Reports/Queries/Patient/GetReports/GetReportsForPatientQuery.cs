using MediatR;
using Patient.Domain.Entities;
using Patient.Domain.Entities.DTOs.Reports;

namespace Patient.Application.Reports.Queries.Patient.GetReports;

public class GetReportsForPatientQuery : IRequest<List<ReportToShowToPatientDto>>
{

}
