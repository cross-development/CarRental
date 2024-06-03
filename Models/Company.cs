namespace CarRental.Models;

public class Company
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<Car> Cars { get; set; } = new List<Car>();
}