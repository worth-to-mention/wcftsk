using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace awsvclib.Contracts
{
    [DataContract]
    public class Address
    {
        [DataMember]
        public Int32 AddressID { get; set; }
        [DataMember]
        public String AddressLine1 { get; set; }
        [DataMember]
        public String City { get; set; }
        [DataMember]
        public String PostalCode { get; set; }
    }
}
