using Microsoft.EntityFrameworkCore;
using Patient.Domain.Entities.Actors;
using Patient.Domain.Repositories;
using Patient.Infrastructure.Persistence;

namespace Patient.Infrastructure.Repositories;

internal class PatientsRepository(PatientDbContext dbContext) : IPatientsRepository
{
    public async Task<List<Patient.Domain.Entities.Actors.Patient>> GetDoctorsPatients(string doctorId)
    {
        var result = await dbContext.Doctors
            .Include(d => d.Patients)
            .Where(d => d.Id == doctorId)
            .FirstOrDefaultAsync();
        return result.Patients.ToList();
    }
    public async Task<int> CountDoctorsPatients(string doctorId)
    {
        var resultsNumber = await dbContext.Doctors
            .Where(d => d.Id == doctorId)
            .SelectMany(d => d.Patients)
            .CountAsync();
        return resultsNumber;
    }
}
