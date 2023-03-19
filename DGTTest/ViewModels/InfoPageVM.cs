using System.Windows;
using DGTTest.Models;
using Prism.Commands;
using Prism.Mvvm;

namespace DGTTest;

public class InfoPageVM : BindableBase
{
    public Currency Currency { get; }

    public InfoPageVM(Currency currency)
    {
        Currency = currency;
    }
}