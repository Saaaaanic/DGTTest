using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using DGTTest.Models;
using DGTTest.Models.Service;
using Prism.Commands;
using Prism.Mvvm;

namespace DGTTest;

public class MainPageVM : BindableBase, IDataErrorInfo
{
    private readonly CurrencyAPI _modelCurrencies = new CurrencyAPI();
    
    public MainPageVM()
    {
        _modelCurrencies.PropertyChanged += (obj, e) => { RaisePropertyChanged(e.PropertyName); };
        RefreshList = new DelegateCommand<string>((str) =>
        {
            var num = Int32.Parse(str);
            if(num > 0 && num <= 100) _modelCurrencies.GetTopCurrencies(CountOfCurrencies).Wait();
        });
    }

    public int CountOfCurrencies { get; set; }
    public ReadOnlyObservableCollection<Currency> Currencies => _modelCurrencies.PublicCurrencies;
    public DelegateCommand<string> RefreshList { get; }

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