namespace Patient.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Patient.Domain.Entities;
using Patient.Domain.Entities.Actors;
using Patient.Domain.Repositories;
using Patient.Infrastructure.Persistence;

internal class ReportRepository(PatientDbContext dbContext) : IReportRepository
{
    public async Task CreateReport(Report entity, CancellationToken cancellationToken)
    {
        await dbContext.Reports.AddAsync(entity);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<Report> GetReport(int reportId, CancellationToken cancellationToken)
    {
        return await dbContext.Reports
            .Include(r=>r.MedicalRecommandation)
            .Where(r => r.Id == reportId).FirstOrDefaultAsync(cancellationToken);
    }
    public async Task<List<Report>> GetPatientReports(Patient patient, CancellationToken cancellationToken)
    {
        var results = await dbContext.Reports.Where(r => r.PatientId == patient.Id)
            .ToListAsync(cancellationToken);
        return results;
    }

    public async Task<Report> GetReportForPatient(int id, Patient patient, CancellationToken cancellationToken)
    {
        var result = await dbContext.Patients
        .Where(p => p.Id == patient.Id) 
        .Include(p => p.Reports) 
        .SelectMany(p => p.Reports) 
        .Where(r => r.Id == id) 
        .FirstOrDefaultAsync(cancellationToken); 

        return result;
    }

    public async Task<List<Report>> GetDoctorReports(Doctor doctor, CancellationToken cancellationToken)
    {
        var results = await dbContext.Reports
                    .Include(r => r.DoctorsToCheck)
                    .Include(r=>r.Patient)
                    .Where(r => r.DoctorsToCheck.Any(d => d.Id == doctor.Id))
                    .ToListAsync(cancellationToken);
        return results;
    }

    public async Task<Report> GetReportForDoctor(int id, Doctor doctor, CancellationToken cancellationToken)
    {

        var result = await dbContext.Doctors
        .Where(d => d.Id == doctor.Id) 
        .Include(d => d.ReportsToCheck)
        .ThenInclude(r => r.Patient) 
        .Include(d => d.ReportsToCheck)
        .ThenInclude(r => r.DoctorsToCheck) 
        .Include(d => d.ReportsChecked)
        .ThenInclude(r => r.DoctorsWhoChecked) 
        .SelectMany(d => d.ReportsToCheck) 
        .Where(r => r.Id == id) 
        .FirstOrDefaultAsync(cancellationToken); 

        return result;


    }

    public async Task<int> GetDoctorReportsNumber(Doctor doctor, CancellationToken cancellationToken)
    {
        var results = await dbContext.Reports
                    .Include(r => r.DoctorsToCheck)
                    .Where(r => r.DoctorsToCheck.Any(d => d.Id == doctor.Id))
                    .CountAsync(cancellationToken);
        

        return results;
    }

    public async Task AddDoctorsWhoCheckedReport(Doctor doctor, int reportId, CancellationToken cancellationToken)
    {
        var result = await dbContext.Reports
            .Include(r => r.DoctorsWhoChecked)
            .Where(r => r.Id == reportId)
            .FirstOrDefaultAsync(cancellationToken);

        var doctorsWhoChecked = result.DoctorsWhoChecked.ToList();
        doctorsWhoChecked.Add(doctor);
        result.DoctorsWhoChecked = doctorsWhoChecked;
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
