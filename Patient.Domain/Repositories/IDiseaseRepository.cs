using Patient.Domain.Entities;
using Shared.Main;



namespace Patient.Domain.Repositories;

public interface IDiseaseRepository
{
    public Task<int> CountPatientsCurrentDiseases(string patientId);
    public Task<IEnumerable<Disease>> SearchDiseases(string searchTerm);
    public Task AddPatientsDiseases(List<PatientsDisease> patientsDiseases);
    public Task<List<PatientsDisease>> GetPatientsDiseases(string patientId);
    public Task<Disease> GetDiseaseByIdAsync(int id);



}
