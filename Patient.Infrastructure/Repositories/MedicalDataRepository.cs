using Patient.Domain.Entities;
using Patient.Domain.Repositories;
using Patient.Infrastructure.Persistence;
using Patient.Domain.Entities.DTOs;
using Patient.Domain.Interfaces;
using Patient.Domain.Entities.Actors;
using Microsoft.EntityFrameworkCore;

namespace Patient.Infrastructure.Repositories;

internal class MedicalDataRepository(PatientDbContext dbContext) : IMedicalDataRepository
{
    public async Task SaveChanges(CancellationToken cancellationToken)
    {        
        await dbContext.SaveChangesAsync();
    }

    public async Task<List<MedicalFile>> GetPatientFiles(Patient.Domain.Entities.Actors.Patient patient, CancellationToken cancellationToken)
    {
        var results = await dbContext.MedicalFiles.Where(m=>m.PatientId == patient.Id).ToListAsync();
        return results;
    }
    
}
