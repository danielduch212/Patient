using Patient.Domain.Entities;
using Patient.Domain.Entities.Actors;

namespace Patient.Domain.Repositories;

public interface IReportRepository
{
    public Task CreateReport(Report entity, CancellationToken cancellationToken);
    public Task<List<Report>> GetPatientReports(Patient.Domain.Entities.Actors.Patient patient, CancellationToken cancellationToken);
    public Task<Report> GetReportForPatient(int id, Patient.Domain.Entities.Actors.Patient patient, CancellationToken cancellationToken);
    public Task<Report> GetReportForDoctor(int id, Doctor doctor, CancellationToken cancellationToken);
    public Task<List<Report>> GetDoctorReports(Doctor doctor, CancellationToken cancellationToken);
    public Task<Report> GetReport(int reportId, CancellationToken cancellationToken);
    public Task<int> GetDoctorReportsNumber(Doctor doctor, CancellationToken cancellationToken);
    public Task AddDoctorsWhoCheckedReport(Doctor doctor, int reportId, CancellationToken cancellationToken);


}
