using System.Collections.ObjectModel;
using System.Threading.Tasks;
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
        
    }
    
    public ReadOnlyObservableCollection<Currency> Currencies => _modelCurrencies.PublicCurrencies;
    public DelegateCommand NavigateToCurrencyDetailsCommand { get; }
}