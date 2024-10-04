using Microsoft.EntityFrameworkCore;
using Patient.Domain.Repositories;
using Patient.Infrastructure.Persistence;

namespace Patient.Infrastructure.Repositories;

internal class DiseaseRepository(PatientDbContext dbContext) : IDiseaseRepository
{

    public async Task<int> CountPatientsCurrentDiseases(string patientId)
    {
        var patient = await dbContext.Patients
            .Include(p => p.CurrentlyTreatedDiseases)
            .FirstOrDefaultAsync(p => p.Id == patientId);

        var result = patient.CurrentlyTreatedDiseases.Count(); 
        return result;
    }
}
