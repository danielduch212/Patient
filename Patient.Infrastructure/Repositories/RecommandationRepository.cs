using Patient.Domain.Entities;
using Patient.Domain.Repositories;
using Patient.Infrastructure.Persistence;

namespace Patient.Infrastructure.Repositories;

internal class RecommandationRepository(PatientDbContext dbContext) : IRecommandationRepository
{
    public async Task CreateRecommandation(MedicalRecommandation entity)
    {
        await dbContext.MedicalRecommandations.AddAsync(entity);
        await dbContext.SaveChangesAsync();
    }
}
