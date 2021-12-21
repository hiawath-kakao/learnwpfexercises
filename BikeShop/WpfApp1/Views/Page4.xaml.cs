
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Page3.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Page4 : UserControl
    {
        private string _defaultPath;
        Binding binding;
        public Page4()
        {
            InitializeComponent();

            binding = new Binding("TestText");

            txtValue.SetBinding(TextBox.TextProperty, binding);
            //lblValue.SetBinding(Button.ContentProperty, new Binding("Test"));

        }

        private void TestButton(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog { InitialDirectory = _defaultPath };
            dialog.ShowDialog();
            //txtValue.Text = dialog.FileName;

            ((HomeController)(this.DataContext)).TestText= dialog.FileName;
        }
    }
}
