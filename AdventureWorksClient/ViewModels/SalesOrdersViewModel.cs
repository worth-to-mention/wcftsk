using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AdventureWorksClient.Views;

using AdventureWorksClient.AdventureWorksServiceReference;
using System.Threading;

namespace AdventureWorksClient.ViewModels
{
    public class SalesOrdersViewModel : ViewModel
    {



        private ObservableCollection<SalesOrder> salesOrders    = null;
        private ICollection<Int32> pageSizes                    = new Collection<Int32>() {1, 30, 50, 100};

        private Int32 currentPage           = 0;
        private Int32 pageSize              = 30;
        private Int32 ordersCount           = 0;
        private SalesOrder selectedOrder    = null;


        private ICommand nextPage;
        private ICommand prevPage;

        private SalesOrdersView view;
        private AdventureWorksServiceReference.AdventuresWorksClient client;
        
        public SalesOrdersViewModel(SalesOrdersView view)
        {
            this.view = view;
            new Thread(() =>
            {
                client = new AdventureWorksServiceReference.AdventuresWorksClient();
                OrdersCount = client.GetSalesOrdersCount();
                SalesOrders = new ObservableCollection<SalesOrder>(
                    client.GetSalesOrders(currentPage * pageSize, pageSize)
                );
            }).Start();
        }

        #region View data source

        public ObservableCollection<SalesOrder> SalesOrders
        {
            get
            {
                return salesOrders;
            }
            set
            {
                if (salesOrders != value)
                {
                    salesOrders = value;
                    OnPropertyChanged("SalesOrders");
                }
            }
        }

        public Int32 CurrentPage
        {
            get
            {
                return currentPage;
            }
            set
            {
                if (currentPage != value)
                {
                    currentPage = value;
                    OnPropertyChanged("CurrentPage");
                    OnPropertyChanged("PagingInfo");
                }
            }
        }

        public Int32 PageSize
        {
            get { return pageSize; }
            set
            {
                if (pageSize != value)
                {
                    pageSize = value;
                    OnPropertyChanged("PageSize");
                    OnPropertyChanged("PagingInfo");
                }
            }
        }

        public ICollection<Int32> PageSizes
        {
            get { return pageSizes; }
        }

        public Int32 OrdersCount
        {
            get { return ordersCount; }
            set
            {
                if (ordersCount != value)
                {
                    ordersCount = value;
                    OnPropertyChanged("OrdersCount");
                    OnPropertyChanged("PagingInfo");
                }
            }
        }

        public String PagingInfo
        {
            get
            {
                return String.Format("Showing {0}-{1} of {2} elements.",
                    CurrentPage * PageSize,
                    (CurrentPage + 1) * PageSize,
                    OrdersCount
                );
            }
        }

        public SalesOrder SelectedOrder
        {
            get { return selectedOrder; }
            set
            {
                if (selectedOrder != value)
                {
                    selectedOrder = value;
                    OnPropertyChanged("SelectedOrder");
                }
            }
        }
        #endregion

        #region Commands

        public ICommand NextPage
        {
            get
            {
                if (nextPage == null)
                {
                    nextPage = new Command(x =>
                    {
                        SalesOrders = new ObservableCollection<SalesOrder>(
                            client.GetSalesOrders(++CurrentPage * PageSize, PageSize)
                        );
                        OnPropertyChanged("PagingInfo");
                    }, x => (CurrentPage + 1) * PageSize < OrdersCount);
                }
                return nextPage;
            }
        }

        public ICommand PrevPage
        {
            get
            {
                if (prevPage == null)
                {
                    prevPage = new Command(x =>
                    {
                        SalesOrders = new ObservableCollection<SalesOrder>(
                            client.GetSalesOrders(--CurrentPage * PageSize, PageSize)
                        );
                        OnPropertyChanged("PagingInfo");
                    }, 
                        x => (CurrentPage - 1) >= 0
                    );
                }
                return prevPage;
            }
        }
        #endregion
    }
}
