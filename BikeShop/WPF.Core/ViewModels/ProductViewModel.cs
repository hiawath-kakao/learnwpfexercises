
using Microsoft.Toolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WPF.Core.Model;


namespace WPF.Core.ViewModels
{
    public class ProductViewModel : Notifier
    {

        private ObservableCollection<Product> products;
        public ObservableCollection<Product> Products
        {
            get
            {
                return products;
            }
            set
            {
                SetProperty(ref products, value);
            }
        }

        public List<Product> GetProduct()
        {
            List<Product> list = new List<Product>();
            list = new List<Product>();
            list.Add(new Product { Name = "1", Description = "a1" });
            list.Add(new Product { Name = "2", Description = "a2" });
            list.Add(new Product { Name = "3", Description = "a3" });
            list.Add(new Product { Name = "4", Description = "a4" });
            //products.Add(new Product { Name = "5", Description = "a5" });
            //products.Add(new Product { Name = "6", Description = "a6" });
            //products.Add(new Product { Name = "7", Description = "a7" });
            //products.Add(new Product { Name = "8", Description = "a8" });
            //products.Add(new Product { Name = "9", Description = "a9" });
            //products.Add(new Product { Name = "10", Description = "a10" });


            return list;

        }



        public ProductViewModel()
        {
            List<Product> list = GetProduct();
            Products = new ObservableCollection<Product>(list);

        }

        public string Page1Name { get; set; }
        public string Page1Description { get; set; }

        private void Signup_()
        {
            Products.Add(new Product { Name = Page1Name, Description = Page1Description });
        }

        private RelayCommand signupCommand;
        public ICommand SignupCommand => signupCommand ??= new RelayCommand(Signup_);

 
    }


}
