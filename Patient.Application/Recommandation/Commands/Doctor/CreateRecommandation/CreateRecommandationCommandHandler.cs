using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Patient.Application.Account;
using Patient.Application.Users;
using Patient.Domain.Entities;
using Patient.Domain.Interfaces;
using Patient.Domain.Repositories;


namespace Patient.Application.Recommandation.Commands.Doctor.CreateRecommandation;

internal class CreateRecommandationCommandHandler(ILogger<CreateRecommandationCommandHandler> logger,
    IdentityUserAccessor userAccessor, UserManager<Domain.Entities.Actors.Doctor> doctorManager,
    IUserContext userContext, HttpClient _httpClient,
    IRecommandationRepository recommandationRepository, IMapper mapper,
    IReportRepository reportRepository) : IRequestHandler<CreateRecommandationCommand, bool>
{
    public async Task<bool> Handle(CreateRecommandationCommand request, CancellationToken cancellationToken)
    {
        var user = userContext.GetCurrentUser();
        var doctor = await doctorManager.FindByEmailAsync(user.Email);
        logger.LogInformation($"Creating recommandation for report: {request.MedicalRecommandationDto.ReportId} by doctor {doctor.Id}");
        var prescription = mapper.Map<Prescription>(request.MedicalRecommandationDto.Prescription);
        if (prescription == null) throw new Exception("Error from mapping prescription");

        prescription.DoctorId = doctor.Id;
        prescription.DateOfIssue = DateOnly.FromDateTime(DateTime.Today);
        prescription.DateOfExpiration = prescription.DateOfIssue.AddDays(30);  

        var data = request.MedicalRecommandationDto;
        

        var report = await reportRepository.GetReport(data.ReportId.Value);
        MedicalRecommandation recommandation = new()
        {
            Description = data.Description,
            Prescription = prescription,
            AskForVisit = data.AskForVisit,
            AskForVisitOnline = data.AskForVisitOnline,
            PatientId = data.PatientId,
            Report = report,
            DateOfIssue = DateOnly.FromDateTime(DateTime.Today),
            DoctorId = doctor.Id,
        }; 
        await recommandationRepository.CreateRecommandation(recommandation);
        return true;
    }
    


}
