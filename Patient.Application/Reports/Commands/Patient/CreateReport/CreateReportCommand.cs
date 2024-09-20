using MediatR;
using Microsoft.AspNetCore.Http;
using Patient.Domain.Entities.DTOs;

namespace Patient.Application.Reports.Commands.Patient.CreateReport;

public class CreateReportCommand() : IRequest<int>
{
    public string Description { get; set; } = default!;
    public IEnumerable<IFormFile>? Files { get; set; } = new List<IFormFile>();

}
