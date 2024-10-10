using Patient.Domain.Entities.DTOs.PrescriptionRequest;
using Patient.Domain.Entities.DTOs.Recommandation;
using Patient.Domain.Entities.DTOs.Reports;

namespace Patient.Domain.Interfaces;

public interface IDoctorApiService
{
    Task<List<ReportForDoctorDto>> GetReports();
    Task<ReportForDoctorToShowDto> GetReport(string id);
    Task<bool> AddRecommandation(MedicalRecommandationDto dto);
    Task<List<PrescriptionRequestToShowToDoctorDto>> GetPrescriptionRequests();
    Task<bool> PrescribePrescription(PrescriptionRequestToShowToDoctorDto dto);

}
