using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Patient.Domain.Interfaces;
using Patient.Domain.Entities.Actors;
using Patient.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Patient.Infrastructure.ValidationUser.Services;

internal class UserAdditionalValidator(UserManager<Patient.Domain.Entities.Actors.Patient> patientManager,
     UserManager<Doctor> doctorManager ,PatientDbContext dbContext) : IUserAdditionalValidator
{
    public async Task<(bool IsValid, string Message)> ValidatePatientData(string pesel, string email)
    {
        var patient = await patientManager.FindByEmailAsync(email);
        var patient1 = await dbContext.Patients.FirstOrDefaultAsync(p=>p.Pesel == pesel);

        if (patient != null)
        {
            return (false, "Podany email juz istnieje");
        }
        else if ( patient1 != null)
        {
            return (false, "Konto o podanym peselu juz istnieje");
        }
        else
        {
            return (true, "Prawidlowe");
        }
    }
    public async Task<(bool IsValid, string Message)> ValidateDoctorData(string doctorNumber, string email)
    {
        var doctor = await doctorManager.FindByEmailAsync(email);
        var doctor1 = await dbContext.Doctors.FirstOrDefaultAsync(p => p.DoctorNumber == doctorNumber);

        if (doctor != null)
        {
            return (false, "Podany email juz istnieje");
        }
        else if (doctor1 != null)
        {
            return (false, "Konto o podanym numeru lekarza juz istnieje");
        }
        else
        {
            return (true, "Prawidlowe");
        }
    }

    

}
