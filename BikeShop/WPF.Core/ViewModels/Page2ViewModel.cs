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
    public partial class Page2ViewModel : ObservableRecipient, IRecipient<ObservableCollection<Product>>
    {
        private readonly ILogger _logger;

        //[ObservableProperty]
        private ObservableCollection<Product> messageProducts;
        public ObservableCollection<Product> MessageProducts 
        { 
            get => messageProducts;
            set => SetProperty(ref messageProducts, value);
        }   

        public Page2ViewModel(ILogger<Page2ViewModel> logger)
        {
            _logger = logger;
            _logger.LogWarning("{@ILogger}", logger);
            
        }

        public void Receive(ObservableCollection<Product> message)
        {
            MessageProducts = new ObservableCollection<Product>();
            _logger.LogInformation("{@Product}", message);

            foreach (var item in message)
            {
                MessageProducts.Add(item);
            }
            
        }
        [ObservableProperty]
        private string totalPrice;

        [ObservableProperty]
        private string page2Description;
        
        [ObservableProperty]
        private string page2Name;
        

        private ActionCommand addCommand;
        public ICommand AddCommand => addCommand ??= new ActionCommand(Add1);

        private void Add1()
        {
        }

        private ActionCommand removeCommand;
        public ICommand RemoveCommand => removeCommand ??= new ActionCommand(Remove);

        private void Remove()
        {
        }
        
    }
}
