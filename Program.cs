using CarRental.Enums;
using CarRental.Managers;
using CarRental.Models;
using CarRental.Extensions;

namespace CarRental;

public class Program
{
    static void Main(string[] args)
    {
        RentCarCase();

        SaleCarCase();

        UnfitInspectionCase();

        CarWithoutYearCase();

        Console.ReadKey();
    }

    // Handling rent car case
    static void RentCarCase()
    {
        Console.WriteLine("\nRentCarCase");

        Car car = new Car(year: "2020")
        {
            Id = new Guid(),
            VinCode = "1HGCM82633A123456",
            SerialNumber = "SN12345678",
            TransmissionType = TransmissionType.Automatic,
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
            CarId = car.Id,
            Inspector = inspector,
            Date = DateTime.Now
        };

        Company company = new Company
        {
            Id = new Guid(),
            Name = "AutoRentals",
        };

        Deal deal = new Deal(Id: new Guid(),
            CompanyId: company.Id,
            CustomerId: customer.Id,
            DealType: DealType.Rent,
            CarId: car.Id,
            Price: 200.00M,
            DealDate: DateTime.Now);

        var customerManager = new CustomerManager(customer);
        var companyManager = new CompanyManager(company);
        var inspectorManager = new InspectorManager(inspector);
        var dealManager = new DealManager(deal);
        var carManager = new CarManager(car);

        customerManager.CarRented += companyManager.OnCarRented;
        customerManager.CarBought += companyManager.OnCarBought;
        customerManager.MoneyPaid += companyManager.OnPaymentReceived;
        inspectorManager.CarRemoved += companyManager.OnCarRemoved;

        companyManager.AddCar(car);
        customerManager.PayMoney(deal.Price);
        customerManager.RentCar(car);

        dealManager.ConcludeDeal();

        deal.GetDealDetails();

        inspectorManager.InspectCar(car, inspection);
        inspectorManager.RecordInspectionResult(inspection, InspectionResult.Fit);
        inspectorManager.RemoveCarIfUnfit(carManager, inspection);

        customerManager.ReturnCar(car);

        dealManager.TerminateDeal();
    }

    static void SaleCarCase()
    {
        Console.WriteLine("SaleCarCase");

        Car car = new Car(year: "2018")
        {
            Id = new Guid(),
            VinCode = "1HGCM82633A765432",
            SerialNumber = "SN23456789",
            TransmissionType = TransmissionType.Automatic,
            Mark = "Ford Focus"
        };

        Company company = new Company
        {
            Id = new Guid(),
            Name = "AutoRentals",
        };

        var companyManager = new CompanyManager(company);

        companyManager.AddCar(car);

        Customer customer = new Customer
        {
            Id = new Guid(),
            FirstName = "John",
            LastName = "Doe",
            PassportNumber = "P1234567",
            DateOfBirth = new DateTime(1990, 1, 1),
            Gender = Gender.Male
        };

        Deal deal = new Deal(Id: new Guid(),
            CompanyId: company.Id,
            CustomerId: customer.Id,
            DealType: DealType.Purchase,
            CarId: car.Id,
            Price: 15000.00M,
            DealDate: DateTime.Now);

        var dealManager = new DealManager(deal);
        var customerManager = new CustomerManager(customer);
        var carManager = new CarManager(car);

        customerManager.PayMoney(deal.Price);
        customerManager.BuyCar(car);
        dealManager.ConcludeDeal();

        deal.GetDealDetails();

        companyManager.RemoveCar(car);

        Console.WriteLine(carManager.GetCarInfo());
        Console.WriteLine(carManager.GetCarInfo(true));
    }

    static void UnfitInspectionCase()
    {
        Console.WriteLine("\nUnfitInspectionCase");

        Car car = new Car(year: "2019")
        {
            Id = new Guid(),
            VinCode = "1HGCM82633A654321",
            SerialNumber = "SN87654321",
            TransmissionType = TransmissionType.Manual,
            Mark = "Toyota Corolla"
        };

        Inspector inspector = new Inspector
        {
            Id = new Guid(),
            FirstName = "Jane",
            LastName = "Smith",
            StartDate = new DateTime(2020, 5, 1)
        };

        Company company = new Company
        {
            Id = new Guid(),
            Name = "AutoRentals"
        };

        Inspection inspection = new Inspection
        {
            Id = new Guid(),
            CarId = car.Id,
            Inspector = inspector,
            Date = DateTime.Now,
        };

        var carManager = new CarManager(car);
        var companyManager = new CompanyManager(company);
        var inspectorManager = new InspectorManager(inspector);

        companyManager.AddCar(car);

        inspectorManager.InspectCar(car, inspection);
        inspectorManager.RecordInspectionResult(inspection, InspectionResult.Unfit);
        inspectorManager.RemoveCarIfUnfit(carManager, inspection);
    }

    static void CarWithoutYearCase()
    {
        Console.WriteLine("\nCarWithoutYearCase");

        Car car = new Car(year: null)
        {
            Id = new Guid(),
            Mark = "Toyota Corolla"
        };

        var carManager = new CarManager(car);

        Console.WriteLine(carManager.GetCarInfo());
        Console.WriteLine(carManager.GetCarInfo(true));
    }
}
