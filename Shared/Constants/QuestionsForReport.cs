namespace Shared.Constants;

public class QuestionsForReport
{
    public static readonly string Question1 = "Opisz swoje ostatnie odczucia zdrowotne";
    public static readonly string Question2 = "Wymień ostatnio przyjmowane leki";
    public static readonly string Question3 = "Jak przebiega terapia zaproponowana przez lekarza?";
    public static readonly string Question4 = "Czy chcesz coś poprawić w terapii?";


    public static List<string> GetAllQuestions()
    {
        return new List<string>
        {
            Question1,
            Question2, 
            Question3, 
            Question4
        };
    }
}
