using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Patient.Domain.Constants;
using Patient.Domain.Entities;
using Patient.Infrastructure.Persistence;

namespace Patient.Infrastructure.Seeders.DiseaseSeeder;

internal class DiseaseSeeder(PatientDbContext dbContext) : IDiseaseSeeder
{
    public async Task SeedData()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Diseases.Any())
            {
                var diseases = GetDiseases();
                await dbContext.Diseases.AddRangeAsync(diseases);
                await dbContext.SaveChangesAsync();
            }
        }
    }


    private IEnumerable<Disease> GetDiseases()
    {

        List<Disease> diseases = [
            new Disease { Name = "Bezsenność" },
            new Disease { Name = "Nadciśnienie" },
            new Disease { Name = "Cukrzyca" },
            new Disease { Name = "Astma" },
            new Disease { Name = "Migrena" },
            new Disease { Name = "Depresja" },
            new Disease { Name = "Niedokrwistość" },
            new Disease { Name = "Zapalenie stawów" },
            new Disease { Name = "Niedoczynność tarczycy" },
            new Disease { Name = "Padaczka" },
            new Disease { Name = "Alergia" },
            new Disease { Name = "Nieżyt żołądka" },
            new Disease { Name = "Otyłość" },
            new Disease { Name = "Zapalenie migdałków" },
            new Disease { Name = "Zapalenie oskrzeli" },
            new Disease { Name = "Zapalenie płuc" },
            new Disease { Name = "Łuszczyca" },
            new Disease { Name = "Osteoporoza" },
            new Disease { Name = "Zapalenie zatok" },
            new Disease { Name = "Skolioza" },
            new Disease { Name = "Dna moczanowa" },
            new Disease { Name = "Choroba Parkinsona" },
            new Disease { Name = "Choroba Alzheimera" },
            new Disease { Name = "Rak płuc" },
            new Disease { Name = "Wrzód żołądka" },
            new Disease { Name = "Dławica piersiowa" },
            new Disease { Name = "Zapalenie wyrostka robaczkowego" },
            new Disease { Name = "Astma" },
            new Disease { Name = "Ból pleców" },
            new Disease { Name = "Choroba afektywna dwubiegunowa" },
            new Disease { Name = "Zakażenie pęcherza moczowego" },
            new Disease { Name = "Zapalenie oskrzeli" },
            new Disease { Name = "Rak" },
            new Disease { Name = "Zaćma" },
            new Disease { Name = "Celiakia" },
            new Disease { Name = "Ospa wietrzna" },
            new Disease { Name = "Podwyższony poziom cholesterolu" },
            new Disease { Name = "Zespół przewlekłego zmęczenia" },
            new Disease { Name = "Marskość wątroby" },
            new Disease { Name = "Przeziębienie" },
            new Disease { Name = "Zapalenie spojówek" },
            new Disease { Name = "Choroba wieńcowa" },
            new Disease { Name = "Choroba Crohna" },
            new Disease { Name = "Łupież" },
            new Disease { Name = "Otępienie" },
            new Disease { Name = "Zapalenie skóry" },
            new Disease { Name = "Zakrzepica żył głębokich" },
            new Disease { Name = "Zapalenie uchyłków" },
            new Disease { Name = "Zakażenie ucha" },
            new Disease { Name = "Egzema" },
            new Disease { Name = "Zator" },
            new Disease { Name = "Rozedma płuc" },
            new Disease { Name = "Zapalenie mózgu" },
            new Disease { Name = "Endometrioza" },
            new Disease { Name = "Fibromialgia" },
            new Disease { Name = "Zatrucie pokarmowe" },
            new Disease { Name = "Kamienie żółciowe" },
            new Disease { Name = "Grypa żołądkowa" },
            new Disease { Name = "Jaskra" },
            new Disease { Name = "Dna moczanowa" },
            new Disease { Name = "Zapalenie wątroby" },
            new Disease { Name = "Przepuklina" },
            new Disease { Name = "Opryszczka" },
            new Disease { Name = "HIV" },
            new Disease { Name = "HPV" },
            new Disease { Name = "Nadczynność tarczycy" },
            new Disease { Name = "Grypa" },
            new Disease { Name = "Zespół jelita drażliwego" },
            new Disease { Name = "Kamienie nerkowe" },
            new Disease { Name = "Białaczka" },
            new Disease { Name = "Choroba wątroby" },
            new Disease { Name = "Toczeń" },
            new Disease { Name = "Borelioza" },
            new Disease { Name = "Czerniak" },
            new Disease { Name = "Zapalenie opon mózgowych" },
            new Disease { Name = "Migrena" },
            new Disease { Name = "Mononukleoza" },
            new Disease { Name = "Stwardnienie rozsiane" },
            new Disease { Name = "Zawał serca" },
            new Disease { Name = "Osteoporoza" },
            new Disease { Name = "Zapalenie ucha środkowego" },
            new Disease { Name = "Zapalenie trzustki" },
            new Disease { Name = "Choroba Parkinsona" },
            new Disease { Name = "Wrzód trawienny" },
            new Disease { Name = "Zapalenie płuc" },
            new Disease { Name = "Łuszczyca" },
            new Disease { Name = "Reumatoidalne zapalenie stawów" },
            new Disease { Name = "Schizofrenia" },
            new Disease { Name = "Sepsa" },
            new Disease { Name = "Niedokrwistość sierpowata" },
            new Disease { Name = "Zapalenie zatok" },
            new Disease { Name = "Udar mózgu" },
            new Disease { Name = "Gruźlica" },
            new Disease { Name = "Wrzodziejące zapalenie jelita grubego" },
            new Disease { Name = "Zakażenie dróg moczowych" },
            new Disease { Name = "Żylaki" },
            new Disease { Name = "Niedobór witaminy D" },
            new Disease { Name = "Krztusiec" },
            new Disease { Name = "Zika" },
            new Disease {Name = "Covid-19"}

            ];
        return diseases;

    }
}
