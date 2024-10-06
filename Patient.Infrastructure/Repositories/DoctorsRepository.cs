using Patient.Infrastructure.Persistence;
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
    
    public async Task<Doctor> GetPatientsDoctor(string patientId)
    {
        var patient = await dbContext.Patients
            .Include(p => p.Doctors)
            .Where(p => p.Id == patientId)
            .FirstOrDefaultAsync();
        return patient.Doctors.FirstOrDefault();
    }
    public async Task AssignFirstContactDoctorToPatient(string patientId)
    {

        var doctor = await dbContext.Doctors
        .Include(d => d.Patients)
        .Select(d => new
        {
            Doctor = d,
            PatientsCount = d.Patients.Count()
        })
        .OrderBy(d => d.PatientsCount)
        .FirstOrDefaultAsync();

        var patient = await dbContext.Patients
            .Include(p => p.Doctors)
            .FirstOrDefaultAsync(p => p.Id == patientId);

        if (doctor != null && patient != null)
        {
            var patientsDoctorsList = patient.Doctors.ToList();

            if (!patientsDoctorsList.Contains(doctor.Doctor))
            {
                patientsDoctorsList.Add(doctor.Doctor);
            }

            patient.Doctors = patientsDoctorsList;
            var doctorsPatientsList = doctor.Doctor.Patients.ToList();

            if (!doctorsPatientsList.Contains(patient))
            {
                doctorsPatientsList.Add(patient);
            }

            doctor.Doctor.Patients = doctorsPatientsList;
            await dbContext.SaveChangesAsync();
        }
    }
}
