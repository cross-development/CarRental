namespace CarRental;

public class Car
{
    public const string InvalidCar = "Car has no mark";

    public readonly string Year;

    public required string Id { get; set; }
    public string Mark { get; set; }
    public string VinCode { get; set; }
    public string SerialNumber { get; set; }
    public string TransmissionType { get; set; }

    public Car(string year)
    {
        Year = year;
    }

    public void TakeFromParking()
    {
        Console.WriteLine("Car taken from parking.");
    }

    public void SendForRepair()
    {
        Console.WriteLine("Car sent for repair.");
    }

    public void Refuel()
    {
        Console.WriteLine("Car refueled.");
    }

    public void Remove()
    {
        Console.WriteLine("Car removed from the system.");
    }

    public string GetCarInfo()
    {
        return $"ID: {Id}, Year: {Year}, Mark: {Mark ?? InvalidCar}";
    }

    public string GetCarInfo(bool hasChecked)
    {
        if (hasChecked && string.IsNullOrWhiteSpace(Year))
        {
            return InvalidCar;
        }

        return GetCarInfo();
    }
}