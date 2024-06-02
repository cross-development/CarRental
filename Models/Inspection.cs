using CarRental.Enums;

namespace CarRental.Models;

public class Inspection
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public Inspector Inspector { get; set; }
    public InspectionResult Result { get; set; }
    public Guid CarId { get; set; }
}