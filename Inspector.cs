namespace CarRental;

public class Inspector
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string IdNumber { get; set; }
    public DateTime StartDate { get; set; }

    public event EventHandler<Car> CarRemoved;

    public void InspectCar(Car car, Inspection inspection)
    {
        inspection.Date = DateTime.Now;
        inspection.Inspector = this;
        inspection.CarId = car.Id;

        Console.WriteLine($"Inspection done on {inspection.Date} by {FirstName} {LastName}");
    }

    public void RecordInspectionResult(Inspection inspection, InspectionResult result)
    {
        inspection.Result = result;

        Console.WriteLine($"Inspection result recorded: {result}");

        if (result == InspectionResult.Unfit)
        {
            CarRemoved?.Invoke(this, GetCarById(inspection.CarId));
        }
    }

    private Car GetCarById(string carId)
    {
        // This should return a Car object based on the carId. For simplicity, returning a new Car.
        return new Car("Unknown Year") { Id = carId };
    }

    public void RemoveCarIfUnfit(Car car, Inspection inspection)
    {
        if (inspection.Result == InspectionResult.Unfit)
        {
            car.Remove();
            CarRemoved?.Invoke(this, car);
        }
    }
}