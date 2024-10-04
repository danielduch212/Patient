namespace Patient.Domain.Repositories;

public interface IPrescriptionRepository
{
    public Task<int> CountPatientsPrescriptions(string patientId);

}
