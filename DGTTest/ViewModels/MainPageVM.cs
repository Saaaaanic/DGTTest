using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Navigation;
using DGTTest.Models;
using DGTTest.Models.Service;
using Prism.Commands;
using Prism.Mvvm;

namespace DGTTest;

public class MainPageVM : BindableBase, IDataErrorInfo
{
    private readonly CurrencyAPI _modelCurrencies = new CurrencyAPI();
    private CollectionViewSource _currencies = new CollectionViewSource();
    
    public MainPageVM()
    {
        _currencies.Source = _modelCurrencies.PublicCurrencies;
        RefreshList = new DelegateCommand<string>((str) =>
        {
            var num = Int32.Parse(str);
            if(num > 0 && num <= 100) _modelCurrencies.GetTopCurrencies(CountOfCurrencies).Wait();
        });
        Search = new DelegateCommand<string>((str) =>
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                Currencies.View.Filter = null;
            }
            else
            {
                Currencies.View.Filter = item => item is Currency currency && 
                                                 (currency.Name.Contains(str, StringComparison.InvariantCultureIgnoreCase) 
                                              || currency.Symbol.Contains(str, StringComparison.InvariantCultureIgnoreCase));
            }
        });
    }

    public int CountOfCurrencies { get; set; }
    public CollectionViewSource Currencies => _currencies;
    public DelegateCommand<string> RefreshList { get; }
    public DelegateCommand<string> Search { get; }

    // Implementation of IDataErrorInfo interface
    public string Error { get; }
    public string this[string columnName]
    {
        get
        {
            string error = String.Empty;
            if (columnName == "CountOfCurrencies")
            {
                if (CountOfCurrencies <= 0 || CountOfCurrencies > 100) error = "Invalid count!";
            }
            return error;
        }
    }
}