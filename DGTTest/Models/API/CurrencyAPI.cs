using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Documents;
using Prism.Mvvm;

namespace DGTTest.Models.Service;

public class CurrencyAPI : BindableBase, ICurrencyAPI
{
    private ObservableCollection<Currency> _currencies = new ObservableCollection<Currency>();
    public readonly ReadOnlyObservableCollection<Currency> PublicCurrencies;

    public CurrencyAPI()
    {
        GetTopCurrencies(0);
        PublicCurrencies = new ReadOnlyObservableCollection<Currency>(_currencies);
    }
    public void GetTopCurrencies(int count)
    {
        _currencies = new ObservableCollection<Currency>()
        {
            new Currency("Bitcoin", 10),
            new Currency("Bitcoin2", 20),
            new Currency("Bitcoin3", 30)
        };
    }
    
}