using System.ComponentModel.DataAnnotations;

namespace Patient.Api.Components.Pages.Registration.AdditionalClasses;

public sealed class InputRegisterPatientModel
{
    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; } = "";

    [Required]
    [StringLength(10, ErrorMessage = "Hasło musi mieć od {0} do {1} znaków", MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "Hasło")]
    public string Password { get; set; } = "";

    [DataType(DataType.Password)]
    [Display(Name = "Powtórz hasło")]
    [Compare("Password", ErrorMessage = "Hasła nie zgadzają się")]
    public string ConfirmPassword { get; set; } = "";

    [Required]
    [Display(Name = "Imie")]
    public string Name { get; set; } = default!;

    [Required]
    [Display(Name = "Nazwisko")]
    public string Surname { get; set; } = default!;
    [Required]
    [Display(Name = "Data Urodzenia")]
    public DateTime DateOfBirth { get; set; } = default!;

    [Required]
    [Display(Name = "Miasto")]
    public string? City { get; set; }
    [Required]
    [Display(Name = "Ulica")]
    public string? Street { get; set; }
    [Required]
    [Display(Name = "Kod pocztowy")]
    [DataType(DataType.PostalCode)]
    public string? PostalCode { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [Required]
    [Display(Name = "Pesel")]
    [StringLength(11, ErrorMessage = "Pesel musi mieć dokładnie 11 znaków")]
    [MinLength(11, ErrorMessage = "Pesel musi mieć dokładnie 11 znaków")]
    public string Pesel { get; set; } = default!;
}
