using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace WPF.Core.Model
{
    public partial class Product : ObservableObject
    {
        [ObservableProperty]
        private string name;

        [ObservableProperty]
        double price;

        [ObservableProperty]
        private string description;

        [ObservableProperty]
        private bool isChecked;
        

    }
}


