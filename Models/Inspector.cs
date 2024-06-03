using CarRental.Enums;

namespace CarRental.Models;

public class Inspector
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime StartDate { get; set; }
}