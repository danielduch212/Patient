﻿using Patient.Infrastructure.Persistence;
using Patient.Domain.Entities.Actors;
using Patient.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Patient.Infrastructure.Repositories;

internal class DoctorsRepository(PatientDbContext dbContext) :  IDoctorsRepository
{
    public async Task<Doctor> GetDoctorByIdAsync(string id)
    {
        var doctor = await dbContext.Doctors.FirstOrDefaultAsync(d => d.Id == id);
        return doctor;
    }
    public async Task<Doctor> AssignAvailibleDoctor ()
    {
        var doctor = await dbContext.Doctors
            .Include(d => d.ReportsToCheck)
            .Select(d => new
            {
                Doctor = d,
                ReportsCount = d.ReportsToCheck.Count() 
            })
            .OrderBy(d => d.ReportsCount)
            .FirstOrDefaultAsync();

        return doctor.Doctor;
    }
    //w pierwwszej kolejnosci raport ma sprawdzic lekarz pacjenta - lekarz podstawowy jest przydzielany
    //w momencie kiedy user wypelni wywiad medyczny
    public async Task<Doctor> GetPatientsDoctor(string patientId)
    {
        var patient = await dbContext.Patients
            .Include(p => p.Doctors)
            .Where(p => p.Id == patientId)
            .FirstOrDefaultAsync();
        return patient.Doctors.FirstOrDefault();
    }
}
