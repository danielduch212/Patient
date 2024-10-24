using Microsoft.EntityFrameworkCore;
using Patient.Domain.Entities;
using Patient.Domain.Repositories;
using Patient.Infrastructure.Persistence;

namespace Patient.Infrastructure.Repositories;

internal class MedicineRepository(PatientDbContext dbContext) : IMedicineRepository
{
    public async Task<IEnumerable<Medicine>> SearchMedicines(string searchTerm, CancellationToken cancellationToken)
    {
        return await dbContext.Medicines
            .Where(m=>m.Name.Contains(searchTerm.ToLower()))
            .ToListAsync(cancellationToken);
    }
}
