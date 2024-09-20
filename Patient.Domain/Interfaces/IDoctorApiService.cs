namespace Patient.Domain.Interfaces;

public interface IDoctorApiService
{
    public Task<HttpResponseMessage> SendRequestGetReports();
    public Task<HttpResponseMessage> SendRequestGetReport(string id);


}
