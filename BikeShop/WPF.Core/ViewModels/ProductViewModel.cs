
using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using Microsoft.Xaml.Behaviors.Core;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows.Input;
using WPF.Core.Model;


namespace WPF.Core.ViewModels
{
    public partial class ProductViewModel : ObservableRecipient
    {
        private readonly ILogger _logger;

        [ObservableProperty]
        private ObservableCollection<Product> products;

        //public ObservableCollection<Product> Products
        //{
        //    get { return products; }
        //    set { SetProperty(ref products, value, true); }
        //}



        public ProductViewModel(ILogger<ProductViewModel> logger)
        {
            _logger = logger;
            //_logger = Ioc.Default.GetService<Page1ViewModel>();
            // read configuration
            //var test = Ioc.Default.GetService<ILogger>(ProductViewModel);

            List<Product> list = GetProduct();
            
            Products = new ObservableCollection<Product>();
            Products.CollectionChanged += ContentCollectionChanged;
            Products.Add(new Product { Name = "1", Description = "a1", Price=100 });
            Products.Add(new Product { Name = "2", Description = "a2", Price = 200 });
            Products.Add(new Product { Name = "3", Description = "a3", Price = 300 });
            _logger.LogInformation("{@ILogger}", logger);

        }

        private void ContentCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
            {
                foreach (INotifyPropertyChanged removed in e.OldItems)
                {
                    removed.PropertyChanged -= ProductOnPropertyChanged;
                    _logger.LogInformation("remove content");
                }
            }
            else
            {
                foreach (INotifyPropertyChanged added in e.NewItems)
                {
                    added.PropertyChanged += ProductOnPropertyChanged;
                    _logger.LogInformation("add content");
                }
            }

        }
        private void ProductOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            
            var product = sender as Product;
            if(product!=null)
            {
                _logger.LogInformation("{@Product}", product);
                Messenger.Send(Products);

                var checkedTotalPrice = from p in Products
                                        where p.IsChecked
                                        select p.Price;
                double totalPrice = 0;
                foreach (var item in checkedTotalPrice)
                {
                    totalPrice += item;
                }
                TotalPrice = totalPrice.ToString();
            }
            
        }

        public void FuncMessageSendTest()
        {
            Messenger.Send(Products);
        }





        public string Page1Name { get; set; }
        public string Page1Description { get; set; }

        private void Signup_()
        {
            Products.Add(new Product { Name = Page1Name, Description = Page1Description });
        }

        private RelayCommand signupCommand;
        public ICommand SignupCommand => signupCommand ??= new RelayCommand(Signup_);

        private RelayCommand webRequestCommand;
        public ICommand WebRequestCommand => webRequestCommand ??= new RelayCommand(WebRequestTo);

        private void WebRequestTo()
        {
            //WebRequest request = WebRequest.Create("https://docs.microsoft.com");
            //WebResponse response = request.GetResponse();
            //Stream dataStream = response.GetResponseStream();
            //string url = "https://httpbin.org/get";  //테스트 사이트
            string url = "https://docs.microsoft.com";
            string responseText = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Timeout = 30 * 1000; // 30초
            request.Headers.Add("Authorization", "BASIC SGVsbG8="); // 헤더 추가 방법

            using (HttpWebResponse resp = (HttpWebResponse)request.GetResponse())
            {
                HttpStatusCode status = resp.StatusCode;
                Console.WriteLine(status);  // 정상이면 "OK"

                Stream respStream = resp.GetResponseStream();
                using (StreamReader sr = new StreamReader(respStream))
                {
                    responseText = sr.ReadToEnd();
                }
            }

            Console.WriteLine(responseText);

        }

        public ICommand TestCommand => new RelayCommand<object>(TestRun, TestCheck);

        private void TestRun(object x)
        {
            //var a = (x as System.Windows.Controls).Name;
            //MessageBox.Show((x as Button).Name);

        }

        private bool TestCheck(object x)
        {
            return true;
            //return x is Button;
        }

        private RelayCommand itemSelectedCommand;
        public ICommand ItemSelectedCommand => new RelayCommand<object>(SelectedRun, SelectedCheck);

        private void SelectedRun(object x)
        {
            Console.WriteLine("Test");
        }
        private bool SelectedCheck(object x)
        {
            Console.WriteLine("Test");
            return true;
        }

        private ActionCommand button_Click;
        public ICommand Button_Click => button_Click ??= new ActionCommand(PerformButton_Click);

        private void PerformButton_Click()
        {
            foreach (var item in Products)
            {
                if (item.IsChecked)
                {
                    Debug.WriteLine($"{item.Name}");
                }
            }
            
        }

        private ActionCommand addCommand;
        public ICommand AddCommand => addCommand ??= new ActionCommand(Add1);

        private void Add1()
        {
            var last=Products[Products.Count-1];
            Products.Add(new Product { Name = $"{int.Parse(last.Name) + 1}", Description = $"{ "a" + (int.Parse(last.Name) + 1)}" });
        }

        private ActionCommand removeCommand;
        public ICommand RemoveCommand => removeCommand ??= new ActionCommand(Remove);

        private void Remove()
        {
            var last = Products[Products.Count - 1];
            Products.Remove(last);

        }


        private string totalPrice;

        public string TotalPrice { get => totalPrice; set => SetProperty(ref totalPrice, value); }

        public List<Product> GetProduct()
        {
            List<Product> list = new List<Product>
            {
                new Product { Name = "1", Description = "a1" },
                new Product { Name = "2", Description = "a2" },
                new Product { Name = "3", Description = "a3" },
                new Product { Name = "4", Description = "a4" },
                new Product { Name = "5", Description = "a5" },
                new Product { Name = "6", Description = "a6" },
                new Product { Name = "7", Description = "a7" },
                new Product { Name = "8", Description = "a8" },
                new Product { Name = "9", Description = "a9" },
                new Product { Name = "10", Description = "a10" }
            };


            return list;

        }
    }


}
