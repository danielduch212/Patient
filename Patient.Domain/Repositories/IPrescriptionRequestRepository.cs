using Patient.Domain.Entities;

namespace Patient.Domain.Repositories;

public interface IPrescriptionRequestRepository
{
    public Task AddPrescriptionRequest(PrescriptionRequest entity);
    public Task<int> CountPatientsPrescriptions(string patientId);
    public Task<int> CountDoctorsPrescriptionRequests(string doctorId);
    public Task<List<PrescriptionRequest>> GetDoctorsPrescriptionRequests(string doctorId);
    public Task MarkPresriptionRequestAsIssued(int prescriptionId);
    public Task ErasePrescriptionRequest(int prescriptionRequestId);


}
