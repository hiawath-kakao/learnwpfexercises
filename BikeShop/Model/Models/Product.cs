using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace WPF.Core.Model
{
    public class Product : ObservableObject
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        double price;

        public double Price
        {
            get { return price; }
            set { SetProperty(ref price, value); }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }

        private bool isChecked;
        public bool IsChecked
        {
            get
            {
                return isChecked;
            }
            set
            {
                SetProperty(ref isChecked, value);
            }
        }

    }
}


