using Patient.Domain.Entities;

namespace Patient.Domain.Repositories;

public interface IMedicalDataRepository
{
    public Task SaveChanges();
    public Task<List<MedicalFile>> GetPatientFiles(Patient.Domain.Entities.Actors.Patient patient);


}
