using CarRental.Models;

namespace CarRental.Managers;

public sealed class CarManager
{
    public const string InvalidCar = "Car has no mark";

    private readonly Car _car;
    private readonly OutputManager _outputManager;

    public CarManager(Car car, OutputManager outputManager)
    {
        _car = car;
        _outputManager = outputManager;
    }

    public Car Car => _car;

    public void RemoveCar()
    {
        _outputManager.Write("Car removed from the system.");
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