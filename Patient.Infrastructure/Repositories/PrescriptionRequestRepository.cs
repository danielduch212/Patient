using Microsoft.EntityFrameworkCore;
using Patient.Domain.Entities;
using Patient.Domain.Repositories;
using Patient.Infrastructure.Persistence;

namespace Patient.Infrastructure.Repositories;

internal class PrescriptionRequestRepository(PatientDbContext dbContext) : IPrescriptionRequestRepository
{
    public async Task AddPrescriptionRequest(PrescriptionRequest entity)
    {
        await dbContext.PrescriptionRequests.AddAsync(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task<int> CountPatientsPrescriptions(string patientId)
    {
        var results = await dbContext.PrescriptionRequests
            .Where(p => (p.PatientId == patientId && p.IsIssued==false))
            .CountAsync();
        return results;
    }

    public async Task<int> CountDoctorsPrescriptionRequests(string doctorId)
    {
        var prescriptionRequestsNumber = await dbContext.PrescriptionRequests
            .Where(pr => (pr.DoctorId == doctorId) && (pr.IsIssued == false))
            .CountAsync();
        return prescriptionRequestsNumber;
    }

    public async Task<List<PrescriptionRequest>> GetDoctorsPrescriptionRequests(string doctorId)
    {
        var prescriptionRequests = await dbContext.PrescriptionRequests
            .Where(pr=>(pr.IsIssued==false)&&(pr.DoctorId==doctorId))
            .ToListAsync();
        return prescriptionRequests;
    }

    public async Task MarkPresriptionRequestAsIssued(int prescriptionId)
    {
        var prescriptionRequest = await dbContext.PrescriptionRequests
            .FirstOrDefaultAsync(pr=>pr.Id==prescriptionId);
        prescriptionRequest.IsIssued = true;
        await dbContext.SaveChangesAsync();
    }

    public async Task ErasePrescriptionRequest(int prescriptionRequestId)
    {
        var prescriptionRequest = await dbContext.PrescriptionRequests
            .FirstOrDefaultAsync(pr=>pr.Id == prescriptionRequestId);
        dbContext.Remove(prescriptionRequest);
        await dbContext.SaveChangesAsync();
    }


}
