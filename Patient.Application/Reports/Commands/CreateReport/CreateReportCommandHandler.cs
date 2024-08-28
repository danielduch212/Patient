using MediatR;

namespace Patient.Application.Reports.Commands.CreateReport;

internal class CreateReportCommandHandler : IRequestHandler<CreateReportCommand>
{
    public Task Handle(CreateReportCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
