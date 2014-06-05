using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorksService.Contracts
{
    [MessageContract]
    public class ProductImageRequest
    {
        [MessageBodyMember]
        public Int32 ImageID { get; set; }
    }
}
