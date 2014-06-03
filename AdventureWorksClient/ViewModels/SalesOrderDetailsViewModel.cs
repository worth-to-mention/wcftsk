using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureWorksClient.AdventureWorksServiceReference;
using AdventureWorksClient.Views;

namespace AdventureWorksClient.ViewModels
{
    public class SalesOrderDetailsViewModel : ViewModel
    {
        private SalesOrderDetailsView view;

        private ObservableCollection<SalesOrderDetails> orderDetails;

        private AdventuresWorksClient client;

        public SalesOrderDetailsViewModel(SalesOrderDetailsView view, Int32 OrderID)
        {
            this.view = view;

            client = new AdventuresWorksClient();
            orderDetails = new ObservableCollection<SalesOrderDetails>(
                client.GetSalesOrderDetails(OrderID)
            );
        }

        #region Bindings

        public ObservableCollection<SalesOrderDetails> OrderDetails
        {
            get { return orderDetails; }
            set
            {
                if (orderDetails != value)
                {
                    orderDetails = value;
                    OnPropertyChanged("OrderDetails");
                }
            }
        }

        #endregion
    }
}
