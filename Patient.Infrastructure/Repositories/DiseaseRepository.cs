using Microsoft.EntityFrameworkCore;
using Patient.Domain.Entities;
using Patient.Domain.Repositories;
using Patient.Infrastructure.Persistence;
using Shared.Main;

namespace Patient.Infrastructure.Repositories;

internal class DiseaseRepository(PatientDbContext dbContext) : IDiseaseRepository
{
    public async Task<int> CountPatientsCurrentDiseases(string patientId, CancellationToken cancellationToken)
    {
        var patient = await dbContext.Patients
            .Include(p => p.TreatedDiseases)
            .FirstOrDefaultAsync(p => p.Id == patientId, cancellationToken);

        var result = patient.TreatedDiseases.Count(p => p.IsCurrentlyTreated);
        return result;
    }

    public async Task<IEnumerable<Disease>> SearchDiseases(string searchTerm)
    {
        return await dbContext.Diseases
            .Where(d => d.Name.Contains(searchTerm.ToLower()))
            .ToListAsync();
    }

    public async Task AddPatientsDiseases(List<PatientsDisease> patientsDiseases, CancellationToken cancellationToken)
    {
        await dbContext.PatientsDiseases.AddRangeAsync(patientsDiseases, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<PatientsDisease>> GetPatientsDiseases(string patientId, CancellationToken cancellationToken)
    {
        var patient = await dbContext.Patients
            .Include(p => p.TreatedDiseases)
            .FirstOrDefaultAsync(p => p.Id == patientId, cancellationToken);
        return patient.TreatedDiseases.ToList();
    }

    public async Task<Disease> GetDiseaseByIdAsync(int id, CancellationToken cancellationToken)
    {
        var result = await dbContext.Diseases
            .FirstOrDefaultAsync(d => d.Id == id, cancellationToken);
        return result;
    }
}
