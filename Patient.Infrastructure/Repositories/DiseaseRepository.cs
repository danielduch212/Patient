using Microsoft.EntityFrameworkCore;
using Patient.Domain.Entities;
using Patient.Domain.Repositories;
using Patient.Infrastructure.Persistence;
using Shared.Main;

namespace Patient.Infrastructure.Repositories;

internal class DiseaseRepository(PatientDbContext dbContext) : IDiseaseRepository
{

    public async Task<int> CountPatientsCurrentDiseases(string patientId)
    {
        var patient = await dbContext.Patients
            .Include(p => p.TreatedDiseases)
            .FirstOrDefaultAsync(p => p.Id == patientId);

        var result = patient.TreatedDiseases.Count(p => p.IsCurrentlyTreated == true); 
        return result;
    }

    public async Task<IEnumerable<Disease>> SearchDiseases(string searchTerm)
    {
        return await dbContext.Diseases
            .Where(d => d.Name.Contains(searchTerm.ToLower()))
            .ToListAsync();
    }
}
