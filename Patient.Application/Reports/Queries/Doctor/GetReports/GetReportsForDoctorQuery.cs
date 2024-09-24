using MediatR;
using Patient.Domain.Entities;
using Patient.Domain.Entities.DTOs.Reports;

namespace Patient.Application.Reports.Queries.Doctor.GetReports;

public class GetReportsForDoctorQuery : IRequest<List<ReportForDoctorDto>>
{

}
