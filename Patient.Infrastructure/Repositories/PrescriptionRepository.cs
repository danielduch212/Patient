using Microsoft.EntityFrameworkCore;
using Patient.Domain.Repositories;
using Patient.Infrastructure.Persistence;

namespace Patient.Infrastructure.Repositories;

internal class PrescriptionRepository(PatientDbContext dbContext) : IPrescriptionRepository
{
    public async Task<int> CountPatientsPrescriptions(string patientId)
    {
        var results = await dbContext.Prescriptions
            .Where(p => p.PatientId == patientId)
            .CountAsync();
        return results;
    }
}
