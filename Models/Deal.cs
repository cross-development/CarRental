using CarRental.Enums;

namespace CarRental.Models;

public class Deal
{
    public Guid Id { get; set; }
    public Guid CarId { get; set; }
    public Guid CompanyId { get; set; }
    public Guid CustomerId { get; set; }
    public decimal Price { get; set; }
    public DateTime DealDate { get; set; }
    public DealType DealType { get; set; }
}