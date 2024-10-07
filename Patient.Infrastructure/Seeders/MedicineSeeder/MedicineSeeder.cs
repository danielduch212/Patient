using HtmlAgilityPack;
using System.Net.Http;
using System.Security.Policy;
using Patient.Infrastructure.Persistence;
using Patient.Domain.Entities;

namespace Patient.Infrastructure.Seeders.MedicineSeeder;

internal class UserSeeder(HttpClient _httpClient, PatientDbContext dbContext) : IUserSeeder
{
    //tutaj bede pobieral nazwy z tej strony: 
    private string url = "https://www.mp.pl/pacjent/leki/";
    private static readonly List<string> htmlItems = new List<string>
    {
        "2", "4", "5", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J",
        "K", "L", "M", "N", "O", "P", "Q", "R", "S", "Ś", "T", "U", "V",
        "W", "X", "Y", "Z", "Ż"
    };


    public async Task SeedMedicines()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Medicines.Any())
            {
                var medicines = await DownloadDataHtml();
                await dbContext.Medicines.AddRangeAsync(medicines);
                await dbContext.SaveChangesAsync();
            }
        }
    }

    private async Task<List<Medicine>> DownloadDataHtml()
    {
        List<Medicine> medicines = new List<Medicine>();
        foreach (var letter in htmlItems)
        {
            var url = $"https://www.mp.pl/pacjent/leki/items.html?letter={letter}";

            try
            {
                var html = await _httpClient.GetStringAsync(url);

                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);

                var liNodes = htmlDoc.DocumentNode.SelectNodes("//ul[@class='list-unstyled drug-list']//li/a");

                if (liNodes != null)
                {
                    foreach (var liNode in liNodes)
                    {
                        Medicine medicine = new Medicine();
                        var drugName = liNode.InnerText.Trim();
                        medicine.Name = drugName;
                        medicines.Add(medicine);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching data for letter {letter}: {ex.Message}");
            }
        }
        return medicines;
    }

    public async Task AddMedicineToDB(Medicine entity)
    {
        await dbContext.Medicines.AddAsync(entity);
        await dbContext.SaveChangesAsync();
    }

}
