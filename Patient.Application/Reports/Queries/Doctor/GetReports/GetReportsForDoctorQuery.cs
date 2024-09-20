using MediatR;
using Patient.Domain.Entities.DTOs;
using Patient.Domain.Entities;

namespace Patient.Application.Reports.Queries.Doctor.GetReports;

public class GetReportsForDoctorQuery : IRequest<List<ReportToShowToDoctorDto>>
{

}
