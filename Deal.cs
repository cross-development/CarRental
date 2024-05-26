namespace CarRental;

public class Deal
{
    public DateTime DealDate { get; set; }
    public string CompanyId { get; set; }
    public string CustomerId { get; set; }
    public DealType DealType { get; set; }
    public string CarId { get; set; }
    public decimal Price { get; set; }

    public void ConcludeDeal()
    {
        DealDate = DateTime.Now;

        Console.WriteLine($"Deal concluded on {DealDate}");
    }

    public void TerminateDeal()
    {
        Console.WriteLine("Deal terminated.");
    }
}