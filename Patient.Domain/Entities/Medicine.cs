namespace Patient.Domain.Entities;

public class Medicine
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public IList<Decimal>? Doses { get; set; } = new List<Decimal>();
}
