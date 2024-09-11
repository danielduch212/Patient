namespace Patient.Domain.Interfaces;

public interface IUserAdditionalValidator
{
    public Task<(bool IsValid, string Message)> ValidatePatientData(string pesel, string email);
    public Task<(bool IsValid, string Message)> ValidateDoctorData(string doctorNumber, string email);

}
