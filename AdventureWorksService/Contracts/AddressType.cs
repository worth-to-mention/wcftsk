using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorksService.Contracts
{
    [DataContract]
    public class AddressType
    {
        [DataMember]
        public Int32 AdrressTypeID { get; set; }
        [DataMember]
        public String Name { get; set; }
    }
}
