using System.Windows;
using DGTTest.Models;
using DGTTest.Models.Service;
using Prism.Commands;
using Prism.Mvvm;

namespace DGTTest;

public class InfoPageVM : BindableBase
{
    private readonly CurrencyAPI _modelCurrencies = new CurrencyAPI();
    public Currency Currency { get; }

    public InfoPageVM(Currency currency)
    {
        _modelCurrencies.GetMarkets(currency).Wait();
        Currency = currency;
    }
}