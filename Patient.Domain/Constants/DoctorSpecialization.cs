namespace Patient.Domain.Constants;

public static class DoctorSpecialization
{
    public const string PrimaryCareDoctor = "Lekarz pierwszego kontaktu";

    public const string CARDIOLOGIST = "Kardiolog";
    public const string DERMATOLOGIST = "Dermatolog";
    public const string ENDOCRINOLOGIST = "Endokrynolog";
    public const string GASTROENTEROLOGIST = "Gastroenterolog";
    public const string NEUROLOGIST = "Neurolog";
    public const string ORTHOPEDIST = "Ortopeda";
    public const string PSYCHIATRIST = "Psychiatra";
    public const string PSYCHOTHERAPIST = "Psychoterapeuta";
    public const string PULMONOLOGIST = "Pulmonolog";
    public const string RADIOLOGIST = "Radiolog";
    public const string ONCOLOGIST = "Onkolog";
    public const string OPHTHALMOLOGIST = "Okulista";
    public const string OTOLARYNGOLOGIST = "Otolaryngolog";
    public const string PEDIATRICIAN = "Pediatra";
    public const string UROLOGIST = "Urolog";
    public const string RHEUMATOLOGIST = "Reumatolog";
    public const string GENERAL_PRACTITIONER = "Lekarz rodzinny";
    public const string GYNECOLOGIST = "Ginekolog";
    public const string DIABETOLOGIST = "Diabetolog";
    public const string SURGEON = "Chirurg";


    public static List<string> GetAllTypes()
    {
        return new List<string>
            {
            //  //
                PrimaryCareDoctor,
                //
                CARDIOLOGIST,
                DERMATOLOGIST,
                ENDOCRINOLOGIST,
                GASTROENTEROLOGIST,
                NEUROLOGIST,
                ORTHOPEDIST,
                PSYCHIATRIST,
                PSYCHOTHERAPIST,
                PULMONOLOGIST,
                RADIOLOGIST,
                ONCOLOGIST,
                OPHTHALMOLOGIST,
                OTOLARYNGOLOGIST,
                PEDIATRICIAN,
                UROLOGIST,
                RHEUMATOLOGIST,
                GENERAL_PRACTITIONER,
                GYNECOLOGIST,
                DIABETOLOGIST,
                SURGEON

            };
    }
}
