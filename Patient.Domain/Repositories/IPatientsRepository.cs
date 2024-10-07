namespace Patient.Domain.Repositories;

public interface IPatientsRepository
{
    public Task<List<Patient.Domain.Entities.Actors.Patient>> GetDoctorsPatients(string doctorId);
    public Task<int> CountDoctorsPatients(string doctorId);


}
