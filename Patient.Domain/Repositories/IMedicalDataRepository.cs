using Patient.Domain.Entities;

namespace Patient.Domain.Repositories;

public interface IMedicalDataRepository
{
    public Task SaveChanges(CancellationToken cancellationToken);
    public Task<List<MedicalFile>> GetPatientFiles(Patient.Domain.Entities.Actors.Patient patient, CancellationToken cancellationToken);


}
