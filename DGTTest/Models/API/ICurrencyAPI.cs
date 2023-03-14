using System.Collections.ObjectModel;

namespace DGTTest.Models.Service;

public interface ICurrencyAPI
{
    public void GetTopCurrencies(int count);
}