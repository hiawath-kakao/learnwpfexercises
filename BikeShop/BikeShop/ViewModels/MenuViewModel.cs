using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BikeShop.ViewModels
{
    internal class MenuViewModel : Notifier
    #region Logic

    #endregion

    #region
    {


        string _TextBox_Text;
        public string TextBox_Text
        {
            get
            {
                return _TextBox_Text;   
            }
            set
            {
                _TextBox_Text=value;
                OnPropertyChanged("TextBox_Text");
              

            }
        }
        private ICommand _leftButtonDownCommand;

        public ICommand LeftMouseButtonDown
        {
            get
            {
                return _leftButtonDownCommand ?? (_leftButtonDownCommand = new RelayCommand(
                   x =>
                   {
                       DoStuff();
                   }));
            }
        }

       

        private static void DoStuff()
        {
            MessageBox.Show("Responding to left mouse button click event...");
        }

    }
    #endregion
}
