using CarRental.Models;

namespace CarRental.Extensions;

public static class DealExtensions
{
    public static void DisplayDealDetails(this Deal deal)
    {
        Console.WriteLine($"Deal Id: {deal.Id}, Deal Details: {deal}");
    }
}