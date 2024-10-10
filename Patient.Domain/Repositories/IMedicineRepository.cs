using Patient.Domain.Entities;

namespace Patient.Domain.Repositories;

public interface IMedicineRepository
{
    public Task<IEnumerable<Medicine>> SearchMedicines(string searchTerm, CancellationToken cancellationToken);

}
