using CarRental.Enums;
using CarRental.Models;

namespace CarRental.Managers;

public sealed class InspectorManager
{
    private readonly Inspector _inspector;
    private readonly OutputManager _outputManager;

    public InspectorManager(Inspector inspector, OutputManager outputManager)
    {
        _inspector = inspector;
        _outputManager = outputManager;
    }

    public event EventHandler<Car> CarRemoved;

    public void InspectCar(Car car, Inspection inspection)
    {
        inspection.Date = DateTime.Now;
        inspection.Inspector = _inspector;
        inspection.CarId = car.Id;

        _outputManager.Write($"Inspection done on {inspection.Date} by {_inspector.FirstName} {_inspector.LastName}");
    }

    public void RecordInspectionResult(Inspection inspection, InspectionResult result)
    {
        inspection.Result = result;

        _outputManager.Write($"Inspection result recorded: {result}");

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