namespace Shared.Constants;

public class DiseaseSymptom
{
    public static readonly string Cough = "Kaszel";
    public static readonly string Fever = "Gorączka";
    public static readonly string Headache = "Ból głowy";
    public static readonly string SoreThroat = "Ból gardła";
    public static readonly string Fatigue = "Zmęczenie";
    public static readonly string Nausea = "Nudności";
    public static readonly string Vomiting = "Wymioty";
    public static readonly string Diarrhea = "Biegunka";
    public static readonly string ShortnessOfBreath = "Dusznica";
    public static readonly string ChestPain = "Ból w klatce piersiowej";
    public static readonly string Dizziness = "Zawroty głowy";
    public static readonly string MusclePain = "Ból mięśni";
    public static readonly string JointPain = "Ból stawów";
    public static readonly string Rash = "Wysypka";
    public static readonly string Chills = "Dreszcze";
    public static readonly string AbdominalPain = "Ból brzucha";
    public static readonly string LossOfAppetite = "Utrata apetytu";
    public static readonly string Sneezing = "Kichanie";
    public static readonly string RunnyNose = "Katar";
    public static readonly string Itching = "Swędzenie";
    public static readonly string BlurredVision = "Zaburzenia widzenia";
    public static readonly string HearingLoss = "Utrata słuchu";
    public static readonly string Cramps = "Skurcze";
    public static readonly string Swelling = "Opuchlizna";
    public static readonly string WeightLoss = "Utrata wagi";
    public static readonly string WeightGain = "Przyrost wagi";

    public static List<string> GetAllSymptoms()
    {
        return new List<string>
        {
            Cough,
            Fever,
            Headache,
            SoreThroat,
            Fatigue,
            Nausea,
            Vomiting,
            Diarrhea,
            ShortnessOfBreath,
            ChestPain,
            Dizziness,
            MusclePain,
            JointPain,
            Rash,
            Chills,
            AbdominalPain,
            LossOfAppetite,
            Sneezing,
            RunnyNose,
            Itching,
            BlurredVision,
            HearingLoss,
            Cramps,
            Swelling,
            WeightLoss,
            WeightGain
        };
    }
}
