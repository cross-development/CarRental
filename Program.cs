using CarRental.Enums;
using CarRental.Models;

namespace CarRental;

public class Program
{
    static void Main(string[] args)
    {
        // Creating a car for rent
        Car car = new Car(year: "2020")
        {
            Id = new Guid(),
            VinCode = "1HGCM82633A123456",
            SerialNumber = "SN12345678",
            TransmissionType = "Automatic",
            Mark = "Honda Accord"
        };

        Customer customer = new Customer
        {
            Id = new Guid(),
            FirstName = "John",
            LastName = "Doe",
            PassportNumber = "P1234567",
            DateOfBirth = new DateTime(1990, 1, 1),
            Gender = Gender.Male
        };

        Inspector inspector = new Inspector
        {
            Id = new Guid(),
            FirstName = "Jane",
            LastName = "Smith",
            StartDate = new DateTime(2020, 5, 1)
        };

        Inspection inspection = new Inspection
        {
            Id = new Guid(),
        };

        Company company = new Company
        {
            Id = new Guid(),
            Name = "AutoRentals"
        };

        Deal deal = new Deal
        {
            CompanyId = company.Id,
            CustomerId = customer.Id,
            DealType = DealType.Rent,
            CarId = car.Id,
            Price = 200.00M
        };

        // Subscribing to the events
        customer.CarRented += company.OnCarRented;
        customer.CarBought += company.OnCarBought;
        customer.MoneyPaid += company.OnPaymentReceived;

        inspector.CarRemoved += company.OnCarRemoved;

        company.AddCar(car);
        customer.PayMoney(deal.Price);
        customer.RentCar(car);

        deal.ConcludeDeal();

        inspector.InspectCar(car, inspection);
        inspector.RecordInspectionResult(inspection, InspectionResult.Fit);
        inspector.RemoveCarIfUnfit(car, inspection);

        customer.ReturnCar(car);

        deal.TerminateDeal();

        // An example for checking an event when a car has not passed an inspection
        Car carUnfit = new Car(year: "2019")
        {
            Id = new Guid(),
            VinCode = "1HGCM82633A654321",
            SerialNumber = "SN87654321",
            TransmissionType = "Manual",
            Mark = "Toyota Corolla"
        };

        company.AddCar(carUnfit);

        Inspection unfitInspection = new Inspection
        {
            Id = new Guid(),
        };

        inspector.InspectCar(carUnfit, unfitInspection);
        inspector.RecordInspectionResult(unfitInspection, InspectionResult.Fit);
        inspector.RemoveCarIfUnfit(carUnfit, unfitInspection);

        // An example for checking an event when a car has been sold
        // Creating a car for sale
        Car carForSale = new Car(year: "2018")
        {
            Id = new Guid(),
            VinCode = "1HGCM82633A765432",
            SerialNumber = "SN23456789",
            TransmissionType = "Automatic",
            Mark = "Ford Focus"
        };

        company.AddCar(carForSale);

        // Creating a sales agreement
        Deal saleDeal = new Deal
        {
            CompanyId = company.Id,
            CustomerId = customer.Id,
            DealType = DealType.Purchase,
            CarId = carForSale.Id,
            Price = 15000.00M
        };

        // Performing actions for the sale
        customer.PayMoney(saleDeal.Price);
        customer.BuyCar(carForSale);
        saleDeal.ConcludeDeal();

        // Checking the availability of cars in the company after the sale
        company.RemoveCar(carForSale);

        // Checking the operation of the GetCarInfo methods
        Console.WriteLine(car.GetCarInfo());
        Console.WriteLine(car.GetCarInfo(true));

        // Creating a car without a year of manufacture to demonstrate the check
        Car carWithoutYear = new Car(year: null)
        {
            Id = new Guid(),
            Mark = "Toyota Corolla"
        };

        // Demonstration of the GetCarInfo methods for a car without a year of manufacture
        Console.WriteLine(carWithoutYear.GetCarInfo());
        Console.WriteLine(carWithoutYear.GetCarInfo(true));

        Console.ReadKey();
    }
}
