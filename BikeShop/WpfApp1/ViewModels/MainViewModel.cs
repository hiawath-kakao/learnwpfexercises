using Microsoft.Expression.Interactivity.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Util;

namespace WpfApp1.MainViewModel
{
    public  class MainViewModel: Notifier
    {

        public MainViewModel()
        {
            //initialize it
            OnSearchCommand = new RelayCommand<string>(param => SearchSmartNotes(param));
        }

        private bool isButtonEnabled;
        public bool IsButtonEnabled
        {
            get => this.isButtonEnabled;
            set
            {
                isButtonEnabled = value;
                OnPropertyChanged("IsButtonEnabled");
            }
        }


        private ICommand mouse1_Command;
        public ICommand Mouse1_Command
        {
            get
            {
                var  Command1 = new RelayCommand<object>(Command1Execute, Command1CanExecute);
                return Command1;
            }
            //    return mouse1_Command ?? (mouse1_Command = new RelayCommand( (ex, Command1CanExecute) =>
            //       {
            //           DoStuff();
            //       }));
            //
            //
            
        }
        private void Command1Execute(object obj)
        {
            Console.WriteLine($"CommandParameter = '{obj}'");
        }
        private bool Command1CanExecute(object obj)
        {
            // Only allow execute if MyData has data
            return this.isButtonEnabled;
        }

        private  void DoStuff()
        {
            Console.WriteLine("Responding to left mouse button click event...");
            TextData = "Hellow";
        }
        private ICommand mouse2_Command;
        public ICommand Mouse2_Command
        {
            get
            {
                return mouse2_Command ?? (mouse2_Command = new RelayCommand<object>(x =>
                {
                    DoStuff();
                }));
            }

        }


        

        public RelayCommand<String> OnSearchCommand { get; set; }


        //Method to call
        private void SearchSmartNotes(String strText)
        {
            //변화는 알수 있는데, 입력된 데이터는 strText로 온다. 
            IsButtonEnabled = String.IsNullOrEmpty(strText) ? false : true;
        }





        private string textData;

        public string TextData
        {
            get { return textData; }
            set 
            { 
                textData = value;
                OnPropertyChanged("TextData"); 
            }
        }

        private ActionCommand mouse3_Command;


        public ICommand Mouse3_Command => mouse3_Command ??= new ActionCommand(Mouse3_);

        private void Mouse3_()
        {

        }
        private double _panelX;
        
        public double PanelX
        {
            get { return _panelX; }
            set
            {
                if (value.Equals(_panelX)) return;
                _panelX = value;
                OnPropertyChanged("PanelX");
            }
        }
        private double _panelY;
        public double PanelY
        {
            get { return _panelY; }
            set
            {
                if (value.Equals(_panelY)) return;
                _panelY = value;
                OnPropertyChanged("PanelY");
            }
        }



    }
}
