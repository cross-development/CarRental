using CarRental.Models;

namespace CarRental.Managers;

public sealed class CarManager
{
    public const string InvalidCar = "Car has no mark";

    private readonly Car _car;

    public CarManager(Car car)
    {
        _car = car;
    }

    public void Remove()
    {
        Console.WriteLine("Car removed from the system.");
    }

    public string GetCarInfo()
    {
        return $"ID: {_car.Id}, Year: {_car.Year}, Mark: {_car.Mark ?? InvalidCar}";
    }

    public string GetCarInfo(bool hasChecked)
    {
        if (hasChecked && string.IsNullOrWhiteSpace(_car.Year))
        {
            return InvalidCar;
        }

        return GetCarInfo();
    }
}