using Patient.Domain.Entities.DTOs.MedicalFiles;
using Patient.Domain.Entities.DTOs.Prescription;
using Patient.Domain.Entities.DTOs.PrescriptionRequest;
using Patient.Domain.Entities.DTOs.Reports;
using Shared.Dtos;

namespace Patient.Domain.Interfaces;

public interface IPatientApiService
{
    Task<bool> AddMedicalFiles(List<MedicalFileDto> medicalFileDtos);
    Task<List<MedicalFileToShowDto>> GetMedicalFiles();
    Task<List<ReportToShowToPatientDto>> GetReports();
    Task<ReportToShowToPatientDto> GetReport(string id);
    Task<List<PrescriptionToShowPatientDto>> GetPrescriptions();
    Task<bool> AddPrescriptionRequest(PrescriptionRequestDto dto);
    Task<bool> AddPatientsDiseases(List<PatientsDiseaseDto> dtos);
    Task<List<PatientsDiseaseDto>> GetPatientsDiseases();

}
