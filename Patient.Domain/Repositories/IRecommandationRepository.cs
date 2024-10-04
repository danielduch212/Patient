using Patient.Domain.Entities;

namespace Patient.Domain.Repositories;

public interface IRecommandationRepository
{
    public Task CreateRecommandation(MedicalRecommandation entity);
    public Task<int> CountPatientsNewRecommandations(string patientId);

}
