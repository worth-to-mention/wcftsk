using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace AdventureWorksClient.Models
{
    public class ProductImage : ViewModels.ViewModel
    {
        private Int32 imageID {get; set;}
        private String fileName { get; set; }
        private BitmapImage imageSource { get; set; }

        public Int32 ImageID
        {
            get { return imageID; }
            set
            {
                if (imageID != value)
                {
                    imageID = value;
                    OnPropertyChanged("ImageID");
                }
            }
        }
        public String FileName
        {
            get { return fileName; }
            set
            {
                if (fileName != value)
                {
                    fileName = value;
                    OnPropertyChanged("FileName");
                }
            }
        }
        public BitmapImage ImageSource
        {
            get { return imageSource; }
            set
            {
                if (imageSource != value)
                {
                    imageSource = value;
                    OnPropertyChanged("ImageSource");
                }
            }
        }

    }
}
