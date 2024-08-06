namespace Patient.Domain.Entities;

public class Payment
{
    public int Id { get; set; }
    public Decimal PaymentAmount { get; set; }
    public DateOnly DateOfPayment { get; set; }

}
