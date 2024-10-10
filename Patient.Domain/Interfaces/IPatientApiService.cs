using Patient.Domain.Entities.DTOs.MedicalFiles;
using Patient.Domain.Entities.DTOs.Prescription;
using Patient.Domain.Entities.DTOs.PrescriptionRequest;
using Patient.Domain.Entities.DTOs.Reports;
using Shared.Dtos;

namespace Patient.Domain.Interfaces;

public interface IPatientApiService
{
    Task<bool> AddMedicalFiles(List<MedicalFileDto> medicalFileDtos, CancellationToken cancellationToken);
    Task<List<MedicalFileToShowDto>> GetMedicalFiles(CancellationToken cancellationToken);
    Task<List<ReportToShowToPatientDto>> GetReports(CancellationToken cancellationToken);
    Task<ReportToShowToPatientDto> GetReport(string id, CancellationToken cancellationToken);
    Task<List<PrescriptionToShowPatientDto>> GetPrescriptions(CancellationToken cancellationToken);
    Task<bool> AddPrescriptionRequest(PrescriptionRequestDto dto, CancellationToken cancellationToken);
    Task<bool> AddPatientsDiseases(List<PatientsDiseaseDto> dtos, CancellationToken cancellationToken);
    Task<List<PatientsDiseaseDto>> GetPatientsDiseases(CancellationToken cancellationToken);

}
