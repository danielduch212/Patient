namespace Patient.Domain.Constants;

public static class MedicalDocumentationType
{
    public static readonly string ResearchResults = "Badania";
    public static readonly string BloodResults = "Badania krwi";
    public static readonly string EKG = "EKG";
    public static readonly string RTG = "RTG";
    public static readonly string MRI = "Rezonans magnetyczny (MRI)";
    public static readonly string CTScan = "Tomografia komputerowa (CT)";
    public static readonly string Ultrasound = "Ultrasonografia";
    public static readonly string UrineTest = "Badanie moczu";
    public static readonly string GlucoseTest = "Badanie poziomu glukozy";
    public static readonly string CholesterolTest = "Badanie poziomu cholesterolu";
    public static readonly string BloodPressure = "Pomiar ciśnienia krwi";
    public static readonly string Spirometry = "Spirometria";
    public static readonly string AllergyTest = "Testy alergiczne";
    public static readonly string HormoneTest = "Badania hormonalne";
    public static readonly string VisionTest = "Badanie wzroku";
    public static readonly string HearingTest = "Badanie słuchu";
    public static readonly string Biopsy = "Biopsja";

    public static List<string> GetAllTypes()
    {
        return new List<string>
            {
                ResearchResults,
                BloodResults,
                EKG,
                RTG,
                MRI,
                CTScan,
                Ultrasound,
                UrineTest,
                GlucoseTest,
                CholesterolTest,
                BloodPressure,
                Spirometry,
                AllergyTest,
                HormoneTest,
                VisionTest,
                HearingTest,
                Biopsy
            };
    }

}
