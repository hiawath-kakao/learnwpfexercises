using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace WPF.Core.ViewModels
{
    public class Page1ViewModel : ObservableObject
    {
        private readonly ILogger _logger;
        public Page1ViewModel(ILogger<Page1ViewModel> logger)
        {
            _logger=logger;
            _logger.LogInformation("Page1ViewModel}");
        }
    }

}



