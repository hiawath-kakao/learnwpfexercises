﻿using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Core;
using WPF.Core.ViewModels;

namespace WpfApp1
{
    public class ViewModelLocator
    {
        // app.xaml.cs 에 등록을 해야 사용할 수 있다. 
        public ProductViewModel PMV => Ioc.Default.GetService<ProductViewModel>();
        public Page1ViewModel P1VM => Ioc.Default.GetService<Page1ViewModel>();
        public Page2ViewModel P2MV => Ioc.Default.GetService<Page2ViewModel>();
        public Page3ViewModel P3MV => Ioc.Default.GetService<Page3ViewModel>();
        public OpenFileDialogViewModel ODMV => Ioc.Default.GetService<OpenFileDialogViewModel>();
        
        //public ILogger  P3MV=> App.Ioc.Default.GetService<ILogger>();
    }
}
