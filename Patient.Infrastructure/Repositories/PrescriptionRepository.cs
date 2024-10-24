using Microsoft.EntityFrameworkCore;
using Patient.Domain.Entities;
using Patient.Domain.Repositories;
using Patient.Infrastructure.Persistence;
using System.Net.WebSockets;

namespace Patient.Infrastructure.Repositories;

internal class PrescriptionRepository(PatientDbContext dbContext) : IPrescriptionRepository
{
    public async Task<int> CountPatientsPrescriptions(string patientId, CancellationToken cancellationToken)
    {
        var results = await dbContext.Prescriptions
            .Where(p => p.PatientId == patientId)
            .CountAsync(cancellationToken);
        return results;
    }

    public async Task<List<Prescription>> GetPatientsPrescriptions(string patientId, CancellationToken cancellationToken)
    {
        var results = await dbContext.Prescriptions
            .Include(p=>p.Doctor)
            .Where(p => p.PatientId == patientId)
            .ToListAsync(cancellationToken);
        return results;
    }

    public async Task<Prescription> GetPrescriptionByIdAsync(int prescriptionId, CancellationToken cancellationToken)
    {
        var result = await dbContext.Prescriptions
            .FirstOrDefaultAsync(p => p.Id == prescriptionId, cancellationToken);
        return result;
    }

    public async Task AddPrescriptionAsync(Prescription entity, CancellationToken cancellationToken)
    {
        var result = await dbContext.Prescriptions.AddAsync(entity);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
    
 
}
