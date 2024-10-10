using Patient.Domain.Entities;
using Shared.Main;



namespace Patient.Domain.Repositories;

public interface IDiseaseRepository
{
    public Task<int> CountPatientsCurrentDiseases(string patientId, CancellationToken cancellationToken);
    public Task<IEnumerable<Disease>> SearchDiseases(string searchTerm);
    public Task AddPatientsDiseases(List<PatientsDisease> patientsDiseases, CancellationToken cancellationToken);
    public Task<List<PatientsDisease>> GetPatientsDiseases(string patientId, CancellationToken cancellationToken);
    public Task<Disease> GetDiseaseByIdAsync(int id, CancellationToken cancellationToken);



}
