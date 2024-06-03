using CarRental.Models;

namespace CarRental.Managers;

public sealed class CompanyManager
{
    private readonly Company _company;
    private readonly OutputManager _outputManager;

    public CompanyManager(Company company, OutputManager outputManager)
    {
        _company = company;
        _outputManager = outputManager;
    }

    public void AddCar(Car car)
    {
        _company.Cars.Add(car);

        _outputManager.Write($"Car with ID {car.Id} added to the company.");
    }

    public void RemoveCar(Car car)
    {
        _company.Cars.Remove(car);

        _outputManager.Write($"Car with ID {car.Id} removed from the company.");
    }

    public void OnCarRented(object sender, Car car)
    {
        _outputManager.Write($"Event: Car with ID {car.Id} has been rented by " +
                          $"{((CustomerManager)sender).Customer.FirstName} {((CustomerManager)sender).Customer.LastName}");
    }

    public void OnCarBought(object sender, Car car)
    {
        _outputManager.Write($"Event: Car with ID {car.Id} has been bought by " +
                          $"{((CustomerManager)sender).Customer.FirstName} {((CustomerManager)sender).Customer.LastName}");
    }

    public void OnPaymentReceived(object sender, decimal amount)
    {
        _outputManager.Write($"Event: Payment of {amount} received from " +
                          $"{((CustomerManager)sender).Customer.FirstName} {((CustomerManager)sender).Customer.LastName}");
    }

    public void OnCarRemoved(object sender, Car car)
    {
        _outputManager.Write($"Event: Car with ID {car.Id} has been removed from the company due to failing inspection.");
    }
}