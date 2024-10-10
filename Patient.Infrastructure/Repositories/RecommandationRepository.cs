using Microsoft.EntityFrameworkCore;
using Patient.Domain.Entities;
using Patient.Domain.Entities.Actors;
using Patient.Domain.Repositories;
using Patient.Infrastructure.Persistence;

namespace Patient.Infrastructure.Repositories;

internal class RecommandationRepository(PatientDbContext dbContext) : IRecommandationRepository
{
    public async Task CreateRecommandation(MedicalRecommandation entity, CancellationToken cancellationToken)
    {
        await dbContext.MedicalRecommandations.AddAsync(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task<int> CountPatientsNewRecommandations(string patientId, CancellationToken cancellationToken)
    {
        var results = await dbContext.MedicalRecommandations
            .Where(mr=>(mr.PatientId==patientId&&mr.DoesPatientChecked==false ))
            .CountAsync();
        return results;
    }
}
