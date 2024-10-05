using Patient.Domain.Entities;

namespace Patient.Domain.Repositories;

public interface IPrescriptionRequestRepository
{
    public Task AddPrescriptionRequest(PrescriptionRequest entity);
    public Task<int> CountPatientsPrescriptions(string patientId);

}
