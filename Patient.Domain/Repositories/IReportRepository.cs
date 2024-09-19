using Patient.Domain.Entities;

namespace Patient.Domain.Repositories;

public interface IReportRepository
{
    public Task CreateReport(Report entity);
    public Task<List<Report>> GetPatientReports(Patient.Domain.Entities.Actors.Patient patient);
    public Task<Report> GetReport(int id);

}
