using System.Collections.Generic;

namespace DGTTest.Models;

public class Currency
{
    public Currency(string name, double price)
    {
        Name = name;
        Price = price;
    }
    public string Name { get; set; }
    public string Code { get; set; }
    public double Price { get; set; }
    public double Volume { get; set; }
    public double PriceChange { get; set; }
    public List<Market> Markets { get; set; }
}