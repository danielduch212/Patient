using Shared.Main;



namespace Patient.Domain.Repositories;

public interface IDiseaseRepository
{
    public Task<int> CountPatientsCurrentDiseases(string patientId);
    public Task<IEnumerable<Disease>> SearchDiseases(string searchTerm);


}
