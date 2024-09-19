namespace Patient.Infrastructure.Repositories;
using Patient.Domain;
using Patient.Domain.Repositories;
using Patient.Domain.Entities;
using Patient.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Patient.Domain.Entities.DTOs;

internal class ReportRepository(PatientDbContext dbContext) : IReportRepository
{
    public async Task CreateReport(Report entity)
    {
        await dbContext.Reports.AddAsync(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task<List<Report>> GetPatientReports(Patient.Domain.Entities.Actors.Patient patient)
    {
        var results = await dbContext.Reports.Where(r => r.PatientId == patient.Id).ToListAsync();
        return results;
    }

    public async Task<Report> GetReport(int id)
    {
        var result = await dbContext.Reports
            .Include(r => r.medicalRecommandation)
            .FirstOrDefaultAsync(r => r.Id == id);
            
        return result;
    }
}
