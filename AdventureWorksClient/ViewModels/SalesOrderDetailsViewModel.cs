using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
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
            var loader = (BitmapImage)App.Current.FindResource("LoaderGif");
            foreach(var detail in OrderDetails)
            {
                for (Int32 i = 0; i < detail.ProductImages.Count; ++i)
                {
                    Models.ProductImage productImage = detail.ProductImages[i];

                }
                foreach (var x in detail.ProductImages)
                {
                    new Action(async () =>
                    {
                        x.ImageSource = loader;
                        ProductImageMessage msg = await client.GetProductImageAsync(x.ImageID, LargeImage: false);
                        var memory = new MemoryStream();
                        var bytesRead = 0;
                        var buffer = new Byte[1024];
                        do
                        {
                            bytesRead = msg.ImageData.Read(buffer, 0, buffer.Length);
                            memory.Write(buffer, 0, bytesRead);
                        } 
                        while (bytesRead > 0);
                        var bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.StreamSource = memory;
                        bitmap.CacheOption = BitmapCacheOption.OnLoad;
                        bitmap.EndInit();
                        x.ImageSource = bitmap;
                    })();
                }
                //detail.ProductImages.ForEach(async x =>
                //{
                //    x.ImageSource = loader;
                //    ProductImageMessage msg = await client.GetProductImageAsync(x.ImageID, LargeImage: false);
                //    var memory = new MemoryStream();
                //    var bytesRead = 0;
                //    var buffer = new Byte[1024];
                //    do
                //    {
                //        bytesRead = msg.ImageData.Read(buffer, 0, buffer.Length);
                //        memory.Write(buffer, 0, bytesRead);
                //    } 
                //    while (bytesRead > 0);
                //    var bitmap = new BitmapImage();
                //    bitmap.BeginInit();
                //    bitmap.StreamSource = memory;
                //    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                //    bitmap.EndInit();
                //    x.ImageSource = bitmap;

                //    var moq = new Models.ProductImage();
                    

                //});
            }
        }
    }
}
