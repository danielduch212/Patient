using MediatR;
using Patient.Domain.Entities.DTOs;

namespace Patient.Application.Reports.Commands.CreateReport;

public class CreateReportCommand(ReportDto report) : IRequest
{
    private ReportDto GivenReport { get; } = report;
}
