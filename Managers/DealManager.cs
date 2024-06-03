using CarRental.Models;

namespace CarRental.Managers;

public sealed class DealManager
{
    private readonly Deal _deal;
    private readonly OutputManager _outputManager;

    public DealManager(Deal deal, OutputManager outputManager)
    {
        _deal = deal;
        _outputManager = outputManager;
    }

    public void ConcludeDeal()
    {
        _outputManager.Write($"Deal concluded on {_deal.DealDate}");
    }

    public void TerminateDeal()
    {
        _outputManager.Write("Deal terminated.");
    }
}