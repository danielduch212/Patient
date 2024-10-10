using Microsoft.EntityFrameworkCore;
using Patient.Domain.Entities;
using Patient.Domain.Repositories;
using Patient.Infrastructure.Persistence;

namespace Patient.Infrastructure.Repositories;

internal class PrescriptionRequestRepository(PatientDbContext dbContext) : IPrescriptionRequestRepository
{
    public async Task AddPrescriptionRequest(PrescriptionRequest entity, CancellationToken cancellationToken)
    {
        await dbContext.PrescriptionRequests.AddAsync(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task<int> CountPatientsPrescriptions(string patientId, CancellationToken cancellationToken)
    {
        var results = await dbContext.PrescriptionRequests
            .Where(p => (p.PatientId == patientId && p.IsIssued==false))
            .CountAsync();
        return results;
    }

    public async Task<int> CountDoctorsPrescriptionRequests(string doctorId, CancellationToken cancellationToken)
    {
        var prescriptionRequestsNumber = await dbContext.PrescriptionRequests
            .Where(pr => (pr.DoctorId == doctorId) && (pr.IsIssued == false))
            .CountAsync();
        return prescriptionRequestsNumber;
    }

    public async Task<List<PrescriptionRequest>> GetDoctorsPrescriptionRequests(string doctorId, CancellationToken cancellationToken)
    {
        var prescriptionRequests = await dbContext.PrescriptionRequests
            .Where(pr=>(pr.IsIssued==false)&&(pr.DoctorId==doctorId))
            .ToListAsync();
        return prescriptionRequests;
    }

    public async Task MarkPresriptionRequestAsIssued(int prescriptionId, CancellationToken cancellationToken)
    {
        var prescriptionRequest = await dbContext.PrescriptionRequests
            .FirstOrDefaultAsync(pr=>pr.Id==prescriptionId);
        prescriptionRequest.IsIssued = true;
        await dbContext.SaveChangesAsync();
    }

    public async Task ErasePrescriptionRequest(int prescriptionRequestId, CancellationToken cancellationToken)
    {
        var prescriptionRequest = await dbContext.PrescriptionRequests
            .FirstOrDefaultAsync(pr=>pr.Id == prescriptionRequestId);
        dbContext.Remove(prescriptionRequest);
        await dbContext.SaveChangesAsync();
    }


}
