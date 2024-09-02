namespace Patient.Infrastructure.Repositories;
using Patient.Domain;
using Patient.Domain.Repositories;
using Patient.Domain.Entities;
using Patient.Infrastructure.Persistence;

internal class ReportRepository(PatientDbContext dbContext) : IReportRepository
{
    public async Task CreateReport(Report entity)
    {
        await dbContext.Reports.AddAsync(entity);
        await dbContext.SaveChangesAsync();
    }
}
