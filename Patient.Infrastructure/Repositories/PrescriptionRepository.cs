using Microsoft.EntityFrameworkCore;
using Patient.Domain.Entities;
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

    public async Task<List<Prescription>> GetPatientsPrescriptions(string patientId)
    {
        var results = await dbContext.Prescriptions
            .Include(p=>p.Doctor)
            .Where(p => p.PatientId == patientId)
            .ToListAsync();
        return results;
    }

 
}
