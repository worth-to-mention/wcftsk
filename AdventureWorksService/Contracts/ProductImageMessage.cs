using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorksService.Contracts
{
    [MessageContract]
    public class ProductImageMessage
    {
        [MessageHeader]
        public String FileName { get; set; }

        [MessageBodyMember]
        public Stream ImageData { get; set; }
    }
}
