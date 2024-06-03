using CarRental.Models;

namespace CarRental.Managers;

public sealed class CustomerManager
{
    private readonly Customer _customer;
    private readonly OutputManager _outputManager;

    public CustomerManager(Customer customer, OutputManager outputManager)
    {
        _customer = customer;
        _outputManager = outputManager;
    }

    public Customer Customer => _customer;

    public event EventHandler<Car> CarRented;
    public event EventHandler<Car> CarBought;
    public event EventHandler<decimal> MoneyPaid;

    public void RentCar(Car car)
    {
        _customer.RentDate = DateTime.Now;

        _outputManager.Write($"Car rented on {_customer.RentDate.Value}");
        
        CarRented?.Invoke(this, car);
    }

    public void BuyCar(Car car)
    {
        _customer.PurchaseDate = DateTime.Now;

        _outputManager.Write($"Car bought on {_customer.PurchaseDate.Value}");
        
        CarBought?.Invoke(this, car);
    }

    public void ReturnCar(Car car)
    {
        _outputManager.Write("Car returned.");
    }

    public void PayMoney(decimal amount)
    {
        _outputManager.Write($"Paid {amount}");

        MoneyPaid?.Invoke(this, amount);
    }
}