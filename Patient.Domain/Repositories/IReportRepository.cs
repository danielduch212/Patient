using Patient.Domain.Entities;

namespace Patient.Domain.Repositories;

public interface IReportRepository
{
    Task CreateReport(Report entity);
}
