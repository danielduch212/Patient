namespace Patient.Domain.Repositories;

public interface IPatientsRepository
{
    public Task<List<Patient.Domain.Entities.Actors.Patient>> GetDoctorsPatients(string doctorId, CancellationToken cancellationToken);
    public Task<int> CountDoctorsPatients(string doctorId, CancellationToken cancellationToken);


}
