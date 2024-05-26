namespace CarRental;

public class Customer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string IdNumber { get; set; }
    public string PassportNumber { get; set; }
    public string DrivingLicenseNumber { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime? RentDate { get; set; }
    public DateTime? PurchaseDate { get; set; }
    public string Gender { get; set; }

    public event EventHandler<Car> CarRented;
    public event EventHandler<Car> CarBought;
    public event EventHandler<decimal> MoneyPaid;

    public void RentCar(Car car)
    {
        RentDate = DateTime.Now;

        Console.WriteLine($"Car rented on {RentDate.Value}");
        
        CarRented?.Invoke(this, car);
    }

    public void BuyCar(Car car)
    {
        PurchaseDate = DateTime.Now;

        Console.WriteLine($"Car bought on {PurchaseDate.Value}");
        
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