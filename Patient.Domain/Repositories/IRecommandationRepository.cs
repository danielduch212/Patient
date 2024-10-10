using Patient.Domain.Entities;

namespace Patient.Domain.Repositories;

public interface IRecommandationRepository
{
    public Task CreateRecommandation(MedicalRecommandation entity, CancellationToken cancellationToken);
    public Task<int> CountPatientsNewRecommandations(string patientId, CancellationToken cancellationToken);

}
