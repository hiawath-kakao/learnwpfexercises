using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF.Core.ViewModels
{
    public class OpenFileDialogViewModel : ObservableObject
    {
        private string selectedPath;
        public string SelectedPath
        {
            get => selectedPath;
            set => SetProperty(ref selectedPath, value);
        }


        private string _defaultPath;


        //public static RelayCommand OpenCommand { get; set; }


        private RelayCommand openCommand;
        public ICommand OpenCommand => openCommand ??= new RelayCommand(ExecuteOpenFileDialog);
        private void ExecuteOpenFileDialog()
        {
            var dialog = new OpenFileDialog { InitialDirectory = _defaultPath };
            dialog.ShowDialog();

            SelectedPath = dialog.FileName;
        }
        
        public OpenFileDialogViewModel()
        {
        }
        public OpenFileDialogViewModel(string defaultPath)
        {
            _defaultPath = defaultPath;
        }
    }
}
