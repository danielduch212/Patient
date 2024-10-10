using Patient.Domain.Entities.Actors;

namespace Patient.Domain.Repositories;

public interface IDoctorsRepository
{
    public Task<Doctor> AssignAvailibleDoctor(CancellationToken cancellationToken);
    public Task<Doctor> GetDoctorByIdAsync(string id, CancellationToken cancellationToken);
    public Task<Doctor> GetPatientsFirstContactDoctor(string patientId, CancellationToken cancellationToken);
    public Task AssignFirstContactDoctorToPatient(string patientId, CancellationToken cancellationToken);
    public Task AssignDoctorSpecializationForDoctor(string doctorId, string DoctorSpecialization, CancellationToken cancellationToken);
    public Task<List<Doctor>> GetPatientsDoctorsToShow(string patientId, CancellationToken cancellationToken);


}
