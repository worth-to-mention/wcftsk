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
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class SalesOrdersView : Window
    {
        private SalesOrdersViewModel viewModel;
        public SalesOrdersView()
        {
            InitializeComponent();
            viewModel = new SalesOrdersViewModel(this);
            DataContext = viewModel;
        }

        private void ListView_ItemDoubleClick(Object sender, RoutedEventArgs args)
        {
            var detailsView = new SalesOrderDetailsView(viewModel.SelectedOrder.OrderID);
            detailsView.Owner = this;
            detailsView.Show();
        }
    }
}
