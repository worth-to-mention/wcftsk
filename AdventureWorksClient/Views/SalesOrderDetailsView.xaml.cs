using System;
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
using System.Windows.Shapes;
using AdventureWorksClient.ViewModels;

namespace AdventureWorksClient.Views
{
    /// <summary>
    /// Interaction logic for SalesOrderDetailsView.xaml
    /// </summary>
    public partial class SalesOrderDetailsView : Window
    {
        private SalesOrderDetailsViewModel viewModel;

        public SalesOrderDetailsView(Int32 salesOrderID)
        {
            InitializeComponent();

            viewModel = new SalesOrderDetailsViewModel(this, salesOrderID);
            DataContext = viewModel;
        }
    }
}
