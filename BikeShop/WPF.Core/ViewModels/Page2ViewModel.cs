using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace WPF.Core.ViewModels
{
    public partial class Page2ViewModel : ObservableObject
    {
        [ObservableProperty]
        string testText="Hello World"; 
    }
}
