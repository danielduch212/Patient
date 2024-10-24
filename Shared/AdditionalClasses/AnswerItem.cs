using System.ComponentModel.DataAnnotations;

namespace Shared.AdditionalClasses;

public class AnswerItem
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Odpowiedź jest wymagana")]
    [MinLength(20, ErrorMessage="Odpowiedz musi zawierać co najmniej 20 znaków" )]
    [MaxLength(300, ErrorMessage = "Odpowiedź może mieć maksymalnie 300 znaków.")]
    public string Answer { get; set; } = "";
}
