using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DGTTest.Models;

public class Currency
{
    public string Id { get; set; }
    public string Symbol { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public double PriceUsd { get; set; }
    public double VolumeUsd24Hr { get; set; }
    public double ChangePercent24Hr { get; set; }
    public ObservableCollection<Market> Markets { get; set; }
}

// Contains data from JSON
public class CurrencyContainer
{
    public ObservableCollection<Currency> Data { get; set; }
}