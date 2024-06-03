using CarRental.Models;

namespace CarRental.Extensions;

public static class DealExtensions
{
    public static void GetDealDetails(this Deal deal)
    {
        Console.WriteLine($"Deal Id: {deal.Id}, Deal Details: {deal}");
    }
}