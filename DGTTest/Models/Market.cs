using System.Collections.ObjectModel;

namespace DGTTest.Models;

public class Market
{
    public string ExchangeId { get; set; }
    public string ExchangeUrl { get; set; }
    public double PriceUsd { get; set; }
}

// Contains data from JSON
public class MarketContainer
{
    public ObservableCollection<Market> Data { get; set; }
}

public class SoloMarketContainer
{
    public Market Data { get; set; }
}