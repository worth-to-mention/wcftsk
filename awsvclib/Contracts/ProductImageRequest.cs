using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace awsvclib.Contracts
{
    [MessageContract]
    public class ProductImageRequest
    {
        [MessageBodyMember]
        public Int32 ImageID { get; set; }

        [MessageBodyMember]
        public Boolean LargeImage { get; set; }
    }
}
