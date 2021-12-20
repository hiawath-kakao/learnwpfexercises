using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Xaml.Behaviors.Core;
using System.ComponentModel.DataAnnotations;
using System.Windows.Input;

namespace WPF.Core.ViewModels
{
    public class Page1ViewModel : ObservableValidator
    {
        private readonly ILogger _logger;
        public Page1ViewModel(ILogger<Page1ViewModel> logger)
        {
            _logger=logger;
            _logger.LogInformation("Page1ViewModel}");
        }
        private string textInput;
        [Required]
        [MinLength(2)]
        [MaxLength(4)]
        public string TextInput 
        { 
            get => textInput;
            set => SetProperty(ref textInput, value,true);
        }
        
        private ActionCommand inputCommand;
        public ICommand InputCommand => inputCommand ??= new ActionCommand(Input);

        private void Input()
        {
        }
    }

}



