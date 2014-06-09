using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace AdventureWorksClient.Models
{
    public class ProductImage
    {
        public Int32 ImageID { get; set; }
        public String FileName { get; set; }
        public BitmapImage ImageSource { get; set; }
    }
}
