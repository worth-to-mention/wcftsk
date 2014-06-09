using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using AdventureWorksClient.AdventureWorksServiceReference;
using AdventureWorksClient.Views;
using AutoMapper;

namespace AdventureWorksClient.ViewModels
{
    public class SalesOrderDetailsViewModel : ViewModel
    {
        private SalesOrderDetailsView view;

        private ObservableCollection<Models.SalesOrderDetails> orderDetails;

        private AdventuresWorksClient client;

        public SalesOrderDetailsViewModel(SalesOrderDetailsView view, Int32 OrderID)
        {
            this.view = view;

            client = new AdventuresWorksClient();
            OrderDetails = new ObservableCollection<Models.SalesOrderDetails>(
                client.GetSalesOrderDetails(OrderID).ToList().Select(x =>
                {
                    return Mapper.Map<SalesOrderDetails, Models.SalesOrderDetails>(x);
                })
            );
            LoadImages();
        }

        #region Bindings

        public ObservableCollection<Models.SalesOrderDetails> OrderDetails
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

        private void LoadImages()
        {
            foreach(var detail in OrderDetails)
            {
                detail.ProductImages.ForEach(async x =>
                {
                    ProductImageMessage msg = await client.GetProductImageAsync(x.ImageID, LargeImage: false);
                    var bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.StreamSource = msg.ImageData;
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.EndInit();
                    
                    x.ImageSource = bitmap;
                    x.FileName = msg.FileName;
                });
            }
        }
    }
}
