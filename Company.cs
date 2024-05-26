namespace CarRental;

public class Company
{
    public string CompanyId { get; set; }
    public string Name { get; set; }
    public List<Car> Cars { get; set; } = new List<Car>();

    public void AddCar(Car car)
    {
        Cars.Add(car);

        Console.WriteLine($"Car with ID {car.Id} added to the company.");
    }

    public void RemoveCar(Car car)
    {
        Cars.Remove(car);

        Console.WriteLine($"Car with ID {car.Id} removed from the company.");
    }

    public void OnCarRented(object sender, Car car)
    {
        Console.WriteLine($"Event: Car with ID {car.Id} has been rented by {((Customer)sender).FirstName} {((Customer)sender).LastName}");
    }

    public void OnCarBought(object sender, Car car)
    {
        Console.WriteLine($"Event: Car with ID {car.Id} has been bought by {((Customer)sender).FirstName} {((Customer)sender).LastName}");
    }

    public void OnPaymentReceived(object sender, decimal amount)
    {
        Console.WriteLine($"Event: Payment of {amount} received from {((Customer)sender).FirstName} {((Customer)sender).LastName}");
    }

    public void OnCarRemoved(object sender, Car car)
    {
        Console.WriteLine($"Event: Car with ID {car.Id} has been removed from the company due to failing inspection.");
    }
}