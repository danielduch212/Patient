using Patient.Domain.Entities.DTOs;

namespace Patient.Domain.Interfaces;

public interface IPatientApiService
{
    public Task<HttpResponseMessage> SendRequestAddMedicalFiles(List<MedicalFileDto> medicalFileDtos);
    public Task<HttpResponseMessage> SendRequestGetMedicalFiles();
}
