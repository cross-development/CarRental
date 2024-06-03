using CarRental.Enums;

namespace CarRental.Models;

public class Customer
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PassportNumber { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime? RentDate { get; set; }
    public DateTime? PurchaseDate { get; set; }
    public Gender Gender { get; set; }
}