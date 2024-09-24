using Patient.Domain.Entities.Actors;

namespace Patient.Domain.Repositories;

public interface IDoctorsRepository
{
    public Task<Doctor> AssignAvailibleDoctor();
    public Task<Doctor> GetDoctorByIdAsync(string id);

}
