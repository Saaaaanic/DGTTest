using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace DGTTest.Models.Service;

public interface ICurrencyAPI
{
    public Task GetTopCurrencies(int count);
    public Task GetMarkets(Currency currency);
}