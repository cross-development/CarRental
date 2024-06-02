namespace CarRental.Models;

public class Car
{
    public readonly string Year;

    public required Guid Id { get; set; }
    public string Mark { get; set; }
    public string VinCode { get; set; }
    public string SerialNumber { get; set; }
    public string TransmissionType { get; set; }

    public Car(string year)
    {
        Year = year;
    }
}