using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
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
                detail.ProductImages.ForEach( x =>
                {
                    Stream stream;
                    x.FileName = client.GetProductImage(x.ImageID, false, out stream);
                    var memory = new MemoryStream();
                    var bytesRead = 0;
                    var buffer = new Byte[1024];
                    do
                    {
                        bytesRead = stream.Read(buffer, 0, buffer.Length);
                        memory.Write(buffer, 0, bytesRead);
                    } while (bytesRead > 0);
                    var bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.StreamSource = memory;
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.EndInit();
                    x.ImageSource = bitmap;
                });
            }
        }
    }
}
