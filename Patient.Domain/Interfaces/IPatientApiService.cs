using Patient.Domain.Entities.DTOs.MedicalFiles;
using Patient.Domain.Entities.DTOs.PrescriptionRequest;

namespace Patient.Domain.Interfaces;

public interface IPatientApiService
{
    public Task<HttpResponseMessage> SendRequestAddMedicalFiles(List<MedicalFileDto> medicalFileDtos);
    public Task<HttpResponseMessage> SendRequestGetMedicalFiles();
    public Task<HttpResponseMessage> SendRequestGetReports();
    public Task<HttpResponseMessage> SendRequestGetReport(string id);
    public Task<HttpResponseMessage> SendRequestGetPrescriptions();
    public Task<HttpResponseMessage> SendRequestAddPrescriptionRequest(PrescriptionRequestDto dto);

}
