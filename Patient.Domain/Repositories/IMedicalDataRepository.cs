using Patient.Domain.Entities;

namespace Patient.Domain.Repositories;

public interface IMedicalDataRepository
{
    public Task AddMedicalFile(MedicalFile medicalFile);

}
