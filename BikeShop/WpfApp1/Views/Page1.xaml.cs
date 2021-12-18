using System;
using System.Collections.Generic;
using System.Data;
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
    /// Page1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Page1 : UserControl
    {
        public Page1()
        {
            InitializeComponent();
        }
        public void DataG()
        {
            DataGrid dg = dg00;
            for (int ji = 0; ji < 10; ji++)
            {
                //var tb = dg00.Columns[0].GetCellContent(dg00.Items[i]) as TextBlock;

                foreach (var rows in dg00.Columns)
                {
                    //var aaa=rows.GetCellContent(dg00.Rows);
                    //Console.WriteLine(rows);
                }

                for (int i = 0; i < 10; i++)
                {
                    var item = dg00.Columns[0].GetCellContent(dg00.Items[i]) as TextBlock;
                }
                
                
                //var item2 = dg00.Items[1] as WPF.Core.Model.Product;//DataGridRow dataGridRow
                //Console.WriteLine(item1.Name); 
                //Console.WriteLine(item2.Name);

                int rowIndex = 0;
                int columIndex = 0;

                //DataRowView item = dg00.Items[rowIndex] as DataRowView;
                //Console.WriteLine(item.Row.ItemArray[columIndex]);
            }

        }


    }
}
