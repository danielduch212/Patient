using Patient.Domain.Entities;
using Patient.Domain.Repositories;
using Patient.Infrastructure.Persistence;

namespace Patient.Infrastructure.Repositories;

internal class MedicalDataRepository(PatientDbContext dbContext) : IMedicalDataRepository
{
    public async Task AddMedicalFile(MedicalFile medicalFile)
    {
        await dbContext.AddAsync(medicalFile);
        await dbContext.SaveChangesAsync();
    }
}
