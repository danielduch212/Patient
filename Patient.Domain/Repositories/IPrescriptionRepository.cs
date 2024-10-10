using Patient.Domain.Entities;

namespace Patient.Domain.Repositories;

public interface IPrescriptionRepository
{
    public Task<int> CountPatientsPrescriptions(string patientId, CancellationToken cancellationToken);
    public Task<List<Prescription>> GetPatientsPrescriptions(string patientId, CancellationToken cancellationToken);
    public Task<Prescription> GetPrescriptionByIdAsync(int prescriptionId, CancellationToken cancellationToken);
    public Task AddPrescriptionAsync(Prescription entity, CancellationToken cancellationToken);

}
