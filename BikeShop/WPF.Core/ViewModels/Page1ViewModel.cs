using WPF.Core.Model;
using System.Collections.ObjectModel;


namespace WPF.Core.ViewModels
{
    public class Page1ViewModel : Notifier
    {
        private ObservableCollection<Product> products;

        public ObservableCollection<Product> Products
        {
            get { return products; }
            set { products = value; }
        }



        public Page1ViewModel()
        {
            products = new ObservableCollection<Product>();

            products.Add(new Product { Name = "1", Description = "a1" });
            products.Add(new Product { Name = "2", Description = "a2" });
            products.Add(new Product { Name = "3", Description = "a3" });
            products.Add(new Product { Name = "4", Description = "a4" });
            products.Add(new Product { Name = "5", Description = "a5" });
            products.Add(new Product { Name = "6", Description = "a6" });
            products.Add(new Product { Name = "7", Description = "a7" });
            products.Add(new Product { Name = "8", Description = "a8" });
            products.Add(new Product { Name = "9", Description = "a9" });
            products.Add(new Product { Name = "10", Description = "a10" });


        }
    }

}



