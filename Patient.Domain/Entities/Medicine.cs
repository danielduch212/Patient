namespace Patient.Domain.Entities;

public class Medicine
{
    public int Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<Decimal>? Doses { get; set; } = default!;
}
