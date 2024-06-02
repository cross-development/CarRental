using CarRental.Models;

namespace CarRental.Managers;

public sealed class DealManager
{
    private readonly Deal _deal;

    public DealManager(Deal deal)
    {
        _deal = deal;
    }

    public void ConcludeDeal()
    {
        _deal.DealDate = DateTime.Now;

        Console.WriteLine($"Deal concluded on {_deal.DealDate}");
    }

    public void TerminateDeal()
    {
        Console.WriteLine("Deal terminated.");
    }
}