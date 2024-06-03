using CarRental.Enums;
using CarRental.Models;

namespace CarRental.Managers;

public sealed class InspectorManager
{
    private readonly Inspector _inspector;

    public InspectorManager(Inspector inspector)
    {
        _inspector = inspector;
    }

    public event EventHandler<Car> CarRemoved;

    public void InspectCar(Car car, Inspection inspection)
    {
        inspection.Date = DateTime.Now;
        inspection.Inspector = _inspector;
        inspection.CarId = car.Id;

        Console.WriteLine($"Inspection done on {inspection.Date} by {_inspector.FirstName} {_inspector.LastName}");
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

    private Car GetCarById(Guid carId)
    {
        // This should return a Car object based on the carId. For simplicity, returning a new Car.
        return new Car("Unknown Year") { Id = carId };
    }

    public void RemoveCarIfUnfit(CarManager carManager, Inspection inspection)
    {
        if (inspection.Result == InspectionResult.Unfit)
        {
            carManager.RemoveCar();
            CarRemoved?.Invoke(this, carManager.Car);
        }
    }
}