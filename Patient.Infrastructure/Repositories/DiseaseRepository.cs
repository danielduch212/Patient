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

    public async Task AddPatientsDiseases(List<PatientsDisease> patientsDiseases)
    {
        await dbContext.PatientsDiseases.AddRangeAsync(patientsDiseases);
        await dbContext.SaveChangesAsync();
    }

    public async Task<List<PatientsDisease>> GetPatientsDiseases(string patientId)
    {
        var patient = await dbContext.Patients
            .Include(p => p.TreatedDiseases)
            .FirstOrDefaultAsync(p=>p.Id==patientId);
        return patient.TreatedDiseases.ToList();
    }

    public async Task<Disease> GetDiseaseByIdAsync(int id)
    {
        var result = await dbContext.Diseases
            .FirstOrDefaultAsync(d=>d.Id==id);
        return result;
    }
}
