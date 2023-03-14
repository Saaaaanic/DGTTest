using System.Collections.ObjectModel;
using DGTTest.Models;
using DGTTest.Models.Service;
using Prism.Commands;
using Prism.Mvvm;

namespace DGTTest;

public class MainPageVM : BindableBase
{
    private readonly CurrencyAPI _modelCurrencies = new CurrencyAPI();
    public MainPageVM()
    {
        _modelCurrencies.PropertyChanged += (obj, e) => { RaisePropertyChanged(e.PropertyName); };
    }

    public ReadOnlyObservableCollection<Currency> Currencies => _modelCurrencies.PublicCurrencies;
    public Currency SelectedCurrency { get; }
    public DelegateCommand NavigateToCurrencyDetailsCommand { get; }
}