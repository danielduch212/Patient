namespace Patient.Domain.Exceptions;

public class NotFullfilledMedicalInterviewException : 
    Exception
{

    public NotFullfilledMedicalInterviewException() : 
        base("Not fullfilled medical interview")
    {

    }
}
