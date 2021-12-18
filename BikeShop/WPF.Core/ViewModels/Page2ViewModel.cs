using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace WPF.Core.ViewModels
{
    public partial class Page2ViewModel : ObservableObject
    {
        private readonly ILogger _logger;

        [ObservableProperty]
        string testText="Hello World";
        public Page2ViewModel(ILogger<Page2ViewModel> logger)
        {
            _logger = logger;
            _logger.LogWarning("{@ILogger}", logger);
        }
    }
}
