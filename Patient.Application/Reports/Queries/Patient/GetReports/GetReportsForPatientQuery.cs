using MediatR;
using Patient.Domain.Entities.DTOs;
using Patient.Domain.Entities;

namespace Patient.Application.Reports.Queries.Patient.GetReports;

public class GetReportsForDoctorQuery : IRequest<List<ReportToShowToPatientDto>>
{

}
