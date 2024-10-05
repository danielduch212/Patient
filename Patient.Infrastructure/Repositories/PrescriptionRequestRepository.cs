using Microsoft.EntityFrameworkCore;
using Patient.Domain.Entities;
using Patient.Domain.Repositories;
using Patient.Infrastructure.Persistence;

namespace Patient.Infrastructure.Repositories;

internal class PrescriptionRequestRepository(PatientDbContext dbContext) : IPrescriptionRequestRepository
{
    public async Task AddPrescriptionRequest(PrescriptionRequest entity)
    {
        await dbContext.PrescriptionRequests.AddAsync(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task<int> CountPatientsPrescriptions(string patientId)
    {
        var results = await dbContext.PrescriptionRequests
            .Where(p => (p.PatientId == patientId && p.IsIssued==false))
            .CountAsync();
        return results;
    }
}
