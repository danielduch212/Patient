using Patient.Domain.Entities.DTOs;

namespace Patient.Domain.Interfaces;

public interface IPatientApiService
{
    public Task<HttpResponseMessage> SendRequestAddMedicalFiles(List<MedicalFileDto> medicalFileDtos);
    public Task<HttpResponseMessage> SendRequestGetMedicalFiles();
    public Task<HttpResponseMessage> SendRequestGetReports();
    public Task<HttpResponseMessage> SendRequestGetReport(string id);

}
