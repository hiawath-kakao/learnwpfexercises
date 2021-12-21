using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Messaging;
using Microsoft.Toolkit.Mvvm.Messaging.Messages;
using Microsoft.Xaml.Behaviors.Core;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WPF.Core.Model;

namespace WPF.Core.ViewModels
{
    public partial class Page4ViewModel : ObservableRecipient
    {
        private readonly ILogger _logger;

        public Page4ViewModel(ILogger<Page4ViewModel> logger)
        {
            _logger = logger;
            _logger.LogWarning("{@ILogger}", logger);
 
            
        }

    }
}
