using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Documents;
using Newtonsoft.Json;
using Prism.Mvvm;

namespace DGTTest.Models.Service;

public class CurrencyAPI : BindableBase, ICurrencyAPI
{
    private const string CoinCapAPI = "https://api.coincap.io/v2/";
    private readonly ObservableCollection<Currency> _currencies = new ObservableCollection<Currency>();
    public readonly ReadOnlyObservableCollection<Currency> PublicCurrencies;
    
    public CurrencyAPI()
    {
        // Called when app started
        GetTopCurrencies(10).Wait();
        PublicCurrencies = new ReadOnlyObservableCollection<Currency>(_currencies);
    }
    
    // Method to get top currencies
    public async Task GetTopCurrencies(int count)
    {
        var url = $"assets?limit={count}";
        string json = await CallApi(url, CoinCapAPI);
        var currencies = JsonConvert.DeserializeObject<CurrencyContainer>(json);
        _currencies.Clear();
        foreach (var currency in currencies.Data)
        {
            _currencies.Add(currency);
        }
    }

    // Method to get markets where u can buy this currency
    public async Task GetMarkets(Currency currency)
    {
        var url = $"markets?baseSymbol={currency.Symbol}";
        string json = await CallApi(url, "https://api.coincap.io/v2/");
        var settings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            MissingMemberHandling = MissingMemberHandling.Ignore
        };
            
        // LINQ expression to select only distinct markets
        var markets = JsonConvert.DeserializeObject<MarketContainer>(json, settings).Data.Where(m =>
            m.PriceUsd != 0).GroupBy(m => m.ExchangeId).Select(g => g.First());
        foreach (var market in markets)
        {
            url = $"exchanges/{market.ExchangeId}";
            json = await CallApi(url, "https://api.coincap.io/v2/");
            var marketData = JsonConvert.DeserializeObject<SoloMarketContainer>(json);
            if (marketData.Data?.ExchangeUrl == null)
            {
                market.ExchangeUrl = String.Empty;
            }
            else
            {
                market.ExchangeUrl = marketData.Data.ExchangeUrl;
            }
        }

        currency.Markets = new ObservableCollection<Market>(markets);
    }
    
    // Method to call API, returns json
    private async Task<string> CallApi(string callUrl, string baseAddress)
    {
        var url = callUrl;
        using var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri(baseAddress);
        
        // .NET manages calls by itself, so without async
        using var response = httpClient.GetAsync(url).Result;
        var json = await response.Content.ReadAsStringAsync();
        return json;
    }
}