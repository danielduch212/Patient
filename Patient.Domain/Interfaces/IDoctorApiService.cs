using Patient.Domain.Entities.DTOs.Recommandation;

namespace Patient.Domain.Interfaces;

public interface IDoctorApiService
{
    public Task<HttpResponseMessage> SendRequestGetReports();
    public Task<HttpResponseMessage> SendRequestGetReport(string id);
    public Task<HttpResponseMessage> SendRequestAddRecommandation(MedicalRecommandationDto dto);

}
