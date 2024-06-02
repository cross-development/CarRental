using CarRental.Models;

namespace CarRental.Managers;

public sealed class CustomerManager
{
    private readonly Customer _customer;

    public CustomerManager(Customer customer)
    {
        _customer = customer;
    }

    public event EventHandler<Car> CarRented;
    public event EventHandler<Car> CarBought;
    public event EventHandler<decimal> MoneyPaid;

    public void RentCar(Car car)
    {
        _customer.RentDate = DateTime.Now;

        Console.WriteLine($"Car rented on {_customer.RentDate.Value}");
        
        CarRented?.Invoke(this, car);
    }

    public void BuyCar(Car car)
    {
        _customer.PurchaseDate = DateTime.Now;

        Console.WriteLine($"Car bought on {_customer.PurchaseDate.Value}");
        
        CarBought?.Invoke(this, car);
    }

    public void ReturnCar(Car car)
    {
        Console.WriteLine("Car returned.");
    }

    public void PayMoney(decimal amount)
    {
        Console.WriteLine($"Paid {amount}");

        MoneyPaid?.Invoke(this, amount);
    }
}