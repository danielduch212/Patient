namespace Patient.Domain.Repositories;

public interface IDiseaseRepository
{
    public Task<int> CountPatientsCurrentDiseases(string patientId);

}
