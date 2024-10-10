using Patient.Domain.Entities;

namespace Patient.Domain.Repositories;

public interface IPrescriptionRequestRepository
{
    public Task AddPrescriptionRequest(PrescriptionRequest entity, CancellationToken cancellationToken);
    public Task<int> CountPatientsPrescriptions(string patientId, CancellationToken cancellationToken);
    public Task<int> CountDoctorsPrescriptionRequests(string doctorId, CancellationToken cancellationToken);
    public Task<List<PrescriptionRequest>> GetDoctorsPrescriptionRequests(string doctorId, CancellationToken cancellationToken);
    public Task MarkPresriptionRequestAsIssued(int prescriptionId, CancellationToken cancellationToken);
    public Task ErasePrescriptionRequest(int prescriptionRequestId, CancellationToken cancellationToken);


}
