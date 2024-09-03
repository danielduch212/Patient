using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Patient.Domain.Interfaces;
using Patient.Domain.Entities.Actors;
using Patient.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Patient.Infrastructure.ValidationUser.Services;

internal class UserAdditionalValidator(UserManager<Patient.Domain.Entities.Actors.Patient> patientManager,
     PatientDbContext dbContext) : IUserAdditionalValidator
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
   // UserManager<Doctor> doctorManager,
   //UserStore<Doctor> doctorStore, 

}
