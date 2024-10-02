namespace Patient.Infrastructure.Repositories;
using Patient.Domain;
using Patient.Domain.Repositories;
using Patient.Domain.Entities;
using Patient.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Patient.Domain.Entities.DTOs;
using Patient.Domain.Entities.Actors;

internal class ReportRepository(PatientDbContext dbContext) : IReportRepository
{
    public async Task CreateReport(Report entity)
    {
        await dbContext.Reports.AddAsync(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task<Report> GetReport(int reportId)
    {
        return await dbContext.Reports
            .Include(r=>r.MedicalRecommandation)
            .Where(r => r.Id == reportId).FirstOrDefaultAsync();
    }
    public async Task<List<Report>> GetPatientReports(Patient patient)
    {
        var results = await dbContext.Reports.Where(r => r.PatientId == patient.Id).ToListAsync();
        return results;
    }

    public async Task<Report> GetReportForPatient(int id, Patient patient)
    {
        var result = await dbContext.Patients
            .Include(p => p.Reports)
            .Where(p => p.Reports.Any(r => r.Id == id))
            .SelectMany(p=>p.Reports)
            .FirstOrDefaultAsync();
        
        return result;
    }

    public async Task<List<Report>> GetDoctorReports(Doctor doctor)
    {
        var results = await dbContext.Reports
                    .Include(r => r.DoctorsToCheck)
                    .Include(r=>r.Patient)
                    .Where(r => r.DoctorsToCheck.Any(d => d.Id == doctor.Id))
                    .ToListAsync();
        return results;
    }

    public async Task<Report> GetReportForDoctor(int id, Doctor doctor)
    {

        var result = await dbContext.Doctors
            .Include(d => d.ReportsToCheck)
            .Include(d=>d.ReportsChecked)
            .Where(r => r.ReportsToCheck.Any(r => r.Id == id))
            .SelectMany(r=>r.ReportsToCheck)
            .Include(r=>r.Patient)
            .Include(r=>r.DoctorsToCheck)
            .Include(r=>r.DoctorsWhoChecked)
            .FirstOrDefaultAsync();

        return result;
         
           
    }

    public async Task<int> GetDoctorReportsNumber(Doctor doctor)
    {
        var results = await dbContext.Reports
                    .Include(r => r.DoctorsToCheck)
                    .Where(r => r.DoctorsToCheck.Any(d => d.Id == doctor.Id))
                    .CountAsync();
        

        return results;
    }
}
