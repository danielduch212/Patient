using Patient.Domain.Entities;
using Patient.Domain.Entities.Actors;

namespace Patient.Domain.Repositories;

public interface IReportRepository
{
    public Task CreateReport(Report entity);
    public Task<List<Report>> GetPatientReports(Patient.Domain.Entities.Actors.Patient patient);
    public Task<Report> GetReportForPatient(int id, Patient.Domain.Entities.Actors.Patient patient);
    public Task<Report> GetReportForDoctor(int id, Doctor doctor);
    public Task<List<Report>> GetDoctorReports(Doctor doctor);
    public Task<Report> GetReport(int reportId);
    public Task<int> GetDoctorReportsNumber(Doctor doctor);

}
