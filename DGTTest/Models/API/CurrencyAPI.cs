using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Documents;
using Newtonsoft.Json;
using Prism.Mvvm;

namespace DGTTest.Models.Service;

public class CurrencyAPI : BindableBase, ICurrencyAPI
{
    private const string CoinCapAPI = "https://api.coincap.io/v2/";
    private ObservableCollection<Currency> _currencies;
    public readonly ReadOnlyObservableCollection<Currency> PublicCurrencies;
    
    public CurrencyAPI()
    {
        // Called when app started
        GetTopCurrencies(10).Wait();
        PublicCurrencies = new ReadOnlyObservableCollection<Currency>(_currencies);
    }
    
    public async Task GetTopCurrencies(int count)
    {
        var url = $"assets?limit={count}";
        using var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri(CoinCapAPI);
        
        // .NET manages calls by itself, so without async
        using var response = httpClient.GetAsync(url).Result;
        var json = await response.Content.ReadAsStringAsync();
        var currencies = JsonConvert.DeserializeObject<CurrencyContainer>(json);
        _currencies = currencies.Data;
        
        // Change the screen data
        RaisePropertyChanged("Currencies");
    }
    
}